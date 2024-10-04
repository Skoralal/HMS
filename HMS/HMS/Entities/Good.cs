using HMS.HMSModels;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace HMS.Entities
{
    public class Good
    {
        [Key]
        public string Name { get; set; } = "";
        public List<Good> _Ingredients;
        public List<Good> Ingredients { get; set; } = new();
        public double _Stock;
        public double Stock
        {  get; set; }
        public double PassiveConsumption { get; set; } = 0;
        public string Icon { get; set; } = "default";
        public string Recipe { get; set; } = "";
        public Good? Parent { get; set; }
        public string Category { get; set; } = "";
        public Good() 
        { 
            Stock = 0;
        }
        public Good(Good good)
        {
            Name = good.Name;
            Ingredients = good.Ingredients.Select(e=>new Good(e) { Parent = this}).ToList();
            //Ingredients = new List<Good>( good.Ingredients);
            Stock = good.Stock;
            PassiveConsumption = good.PassiveConsumption;
            Icon = good.Icon;
            Recipe = good.Recipe;
            Parent = null;
            Category = good.Category;
        }
        public Good(Good good, Good parent)
        {
            Name = good.Name;
            Ingredients = good.Ingredients.Select(e => new Good(e, this)).ToList();
            //Ingredients = new List<Good>( good.Ingredients);
            PassiveConsumption = good.PassiveConsumption;
            Icon = good.Icon;
            Recipe = good.Recipe;
            Parent = parent;
            Stock = good.Stock;
        }
        private void UpdateStockForChildren(double margin)
        {
            foreach (var child in Ingredients)
            {
                if(child.Stock / margin != Stock)
                {
                    child.Stock *= margin;  // This will trigger the setter in each child as well
                }
            }
        }
        public void CascadeUpdateStock()//trouble with partent node being foiled - ings for not just one parent
        {
            List<Good> Deck = new List<Good>() {this};
            for (int i = 0; i < Deck.Count; i++)
            {
                foreach(var Ingredient in Deck[i].Ingredients)
                {
                    Ingredient.Stock *= Stock;
                    Deck.Add(Ingredient);
                }
            }
        }
        public void Cleanse(double stock, Dictionary<string, Good> normals)
        {
            //if (this.Stock == 0)
            //{
            //    this.Stock = 1;
            //    this.Ingredients = normals[this.Name].Ingredients.Select(x => new Good(x)).ToList();
            //}
            //double margin = Stock;
            //List<Good> Deck = new List<Good>() { this };
            //for (int i = 0; i < Deck.Count; i++)
            //{
            //    foreach (var Ingredient in Deck[i].Ingredients)
            //    {
            //        Ingredient.Stock /= margin;
            //        Deck.Add(Ingredient);
            //    }
            //}
            //Stock = stock;
            //this.CascadeUpdateStock();
            this.Ingredients = normals[this.Name].Ingredients.Select(x => new Good(x)).ToList();
            this.Stock = stock;
            this.CascadeUpdateStock();
            
        }
        public Good Cleansed(double stock, Dictionary<string, Good> normals)
        {
            //if(this.Stock == 0)
            //{
            //    this.Stock = 1;
            //    this.Ingredients = normals[this.Name].Ingredients.Select(x=> new Good(x)).ToList();
            //}
            //double margin = Stock;
            //List<Good> Deck = new List<Good>() { this };
            //for (int i = 0; i < Deck.Count; i++)
            //{
            //    foreach (var Ingredient in Deck[i].Ingredients)
            //    {
            //        Ingredient.Stock /= margin;
            //        Deck.Add(Ingredient);
            //    }
            //}
            //Stock = stock;
            //this.CascadeUpdateStock();
            //return this;
            this.Ingredients = normals[this.Name].Ingredients.Select(x => new Good(x)).ToList();
            this.Stock = stock;
            this.CascadeUpdateStock();
            return this;
        }
        public string Consume(double amount, Dictionary<string, Good> normals)
        {
            if(this.Stock - amount < 0)
            {
                return "Creation of anti-matter prevented";
            }
            this.Cleanse(this.Stock - amount, normals);
            return $"Current stock reduced to {this.Stock}";
        }
        public string Cook(double amount, Dictionary<string, Good> normals)
        {
            foreach(var ing in this.Ingredients)
            {
                if (ing.Stock - normals[this.Name].Ingredients.Where(x=>x.Name == this.Name).First().Stock * amount < 0)
                {
                    return $"nope";
                }
            }
            foreach (var ing in this.Ingredients)
            {
                ing.Stock -= amount * normals[this.Name].Ingredients.Where(x => x.Name == this.Name).First().Stock;
            }
            this.Cleanse(amount+this.Stock, normals);
            return $"Current stock increased to {this.Stock}";
        }
        public bool CanBeCooked(HH currentHH)
        {
            var amount = 0.01;
            foreach (var ing in Ingredients)
            {
                if (currentHH.Shops.Contains(ing.Name))
                {
                    return false;
                }
                if (currentHH.GoodsDic[ing.Name].Stock - amount * currentHH.NormalizedGoodsDic[Name].Ingredients
                                        .Where(x => x.Name == ing.Name).First().Stock < 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
