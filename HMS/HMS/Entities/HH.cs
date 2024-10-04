using HMS.HMSModels;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace HMS.Entities
{
    public class HH : DBHH//inherit from dbhh(does not have transformed goods, dishes...)
    {
        
        //public List<Good> AllGoods { get; set; } = new List<Good>();
        //public List<Dish> AllDishes { get; set; } = new List<Dish>();
        public List<Member> AllMembers { get; set; } = new List<Member>();
        public Dictionary<string, Good> GoodsDic { get; set; } = new();
        public Dictionary<string, Good> FutureGoodsDic { get; set; } = new();
        public Dictionary<string, Dish> DishesDic { get; set; } = new();
        public Dictionary<string, Good> NormalizedGoodsDic { get; set; } = new();
        public HH()
        {
        }
        public HH(DBHH dbhh)
        {
            SerializedDish = dbhh.SerializedDish;
            Login = dbhh.Login;
            Password = dbhh.Password;
            SerializedGoods = dbhh.SerializedGoods;
            SerializedMember = dbhh.SerializedMember;
            Shops = dbhh.Shops;
            SerializedNormalizedGoods = dbhh.SerializedNormalizedGoods;
        }
        public void AddGood(Good good)
        {
            if (!GoodsDic.ContainsKey(good.Name))
            {
                GoodsDic.Add(good.Name, good);
                //AllGoods.Add(good);
            }
        }
        public void AddNormalizedGood(Good good)
        {
            if (!NormalizedGoodsDic.ContainsKey(good.Name))
            {
                NormalizedGoodsDic.Add(good.Name, good);
            }
        }
        public void AddDish(Dish dish)
        {
            if (!DishesDic.ContainsKey(dish.ID))
            {
                DishesDic.Add(dish.ID, dish);
            }
            
        }
        public void Forecast(DateTime dateTime)
        {
            FutureGoodsDic.Clear();
            foreach (var pair in GoodsDic)
            {
                FutureGoodsDic.Add(pair.Key, new(pair.Value));
            }
            List<Dish> dishes = DishesDic.Values.Where(x=>x.Time!="Template").Where(x=>Convert.ToDateTime(x.Time) >= DateTime.Today).Where(x => Convert.ToDateTime(x.Time) < dateTime).ToList();
            foreach (var dish in dishes)
            {
                foreach(var good in dish.Contents)
                {
                    FutureGoodsDic[good.Name].Stock -= good.Stock;
                }
            }
        }
    }
}
