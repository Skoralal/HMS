using HMS.HMSModels;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using static Azure.Core.HttpHeader;

namespace HMS.Entities
{
    public class Dish
    {
        private string time = "";

        [Key]
        public string ID { get; set; } = "";//Time+Owner+Name
        public string Name { get; set; } = "";
        public bool Cooked { get; set; } = false;
        public bool Consumed { get; set; } = false ;
        public List<List<Good>> RandomizedContents { get; set; } = new();
        public List<Good> Contents { get; set; } = new List<Good>();//make this a list of list to choose one good from each
        public string Time { get => time;
            set 
            { 
                time = value;
                ID = time + Owner + Name;
            } 
        }
        public string Owner { get; set; } = "";
        public double Amount { get; set; } = 0;
        public string Recipe { get; set; } = "";
        public string Category { get; set; } = "";
        public Dish() { }
        public Dish(Dish oldDish)
        {
            ID = oldDish.ID;
            Name = oldDish.Name;
            Cooked = oldDish.Cooked;
            Consumed = oldDish.Consumed;
            RandomizedContents = new(oldDish.RandomizedContents);
            Contents = new(oldDish.Contents.Select(e=>new Good(e)).ToList());
            Time = oldDish.Time;
            Owner = oldDish.Owner;
            Amount = oldDish.Amount;
            Recipe = oldDish.Recipe;
            Category = oldDish.Category;
        }
        public void RefreshGoods(HH hh, bool forceRefresh=false, bool firstTime = false)
        {
            if(this.Previous(hh.DishesDic) == null && !forceRefresh && !firstTime)
            {
                return;
            }
            List<List<Good>> ready = new();
            List<List<Good>> preFabs = new();
            //exclude repeats (the same thing 2 times in a row)
            for (int i = 0; i < RandomizedContents.Count; i++)
            {
                ready.Add(new());
                preFabs.Add(new());
                foreach (var good in RandomizedContents[i])
                {
                    if (hh.GoodsDic[good.Name].Stock > 0)
                    {
                        ready[i].Add(good);
                    }
                    else if (!hh.Shops.Any(item => hh.GoodsDic[good.Name].Ingredients.Select(e=>e.Name).Contains(item)) && hh.GoodsDic[good.Name].CanBeCooked(hh))
                    {
                        preFabs[i].Add(good);
                    }
                }
            }
            if (firstTime)
            {
                for (int i = 0; i < RandomizedContents.Count; i++)
                {
                    Contents.Add(new());
                    if (!ready[i].IsNullOrEmpty())
                    {
                        Contents[i] = ready[i][new Random().Next(ready[i].Count)];
                    }
                    else if (!preFabs[i].IsNullOrEmpty())
                    {
                        Contents[i] = preFabs[i][new Random().Next(preFabs[i].Count)];
                    }

                    else { Contents[i] = RandomizedContents[i][new Random().Next(RandomizedContents[i].Count)]; }

                }
            }
            else
            {
                for (int i = 0; i < RandomizedContents.Count; i++)
                {
                    if (hh.GoodsDic[Contents[i].Name].Stock > 0)
                    {
                        continue;
                    }
                    if (!ready[i].IsNullOrEmpty())
                    {
                        if (ready[i].Select(x => x.Name).Contains(Contents[i].Name) && ready[i].Count > 1)
                        {
                            ready[i] = ready[i].Where(x => x.Name != Contents[i].Name).ToList();
                        }
                        Contents[i] = ready[i][new Random().Next(ready[i].Count)];
                    }
                    else if (!preFabs[i].IsNullOrEmpty())
                    {
                        if (preFabs[i].Select(x => x.Name).Contains(Contents[i].Name) && preFabs[i].Count > 1)
                        {
                            preFabs[i] = preFabs[i].Where(x => x.Name != Contents[i].Name).ToList();
                        }
                        Contents[i] = preFabs[i][new Random().Next(preFabs[i].Count)];
                    }
                    else
                    {
                        if (RandomizedContents[i].Select(x => x.Name).Contains(Contents[i].Name) && RandomizedContents[i].Count > 1)
                        {
                            Contents[i] = RandomizedContents[i].Where(x => x.Name != Contents[i].Name).ToList()[new Random().Next(RandomizedContents[i].Where(x => x.Name != Contents[i].Name).ToList().Count)];
                        }
                        else { Contents[i] = RandomizedContents[i][new Random().Next(RandomizedContents[i].Count)]; }
                    }
                }
            }
            List<Dish> affected = hh.DishesDic.Values.Where(x => x.Name == Name).Where(x => Convert.ToDateTime(x.Time) > Convert.ToDateTime(Time)).ToList();
            foreach (var dish in affected)
            {
                dish.Contents = Contents;
            }
        }
        public Dish? Previous(Dictionary<string, Dish> allDishesDic)
        {
            List<Dish> localAllDishes = allDishesDic.Values.Select(e=>new Dish(e)).Where(x=>x.Time != "Template").ToList();
            localAllDishes.RemoveAll(x => Convert.ToDateTime(x.Time) >= Convert.ToDateTime(this.Time));
            if (localAllDishes.Count == 0)
            {
                return null;
            }
            localAllDishes = localAllDishes.OrderByDescending(obj => DateTime.Parse(obj.Time)).ToList();
            return localAllDishes[0];
        }
    }
}
