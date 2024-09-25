using HMS.HMSModels;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace HMS.Entities
{
    public class HH : DBHH//inherit from dbhh(does not have transformed goods, dishes...)
    {
        
        //public List<Good> AllGoods { get; set; } = new List<Good>();
        public List<Dish> AllDishes { get; set; } = new List<Dish>();
        public List<Member> AllMembers { get; set; } = new List<Member>();
        public Dictionary<string, Good> GoodsDic { get; set; } = new();
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
            if (!GoodsDic.ContainsKey(dish.Name))
            {
                DishesDic.Add(dish.ID, dish);
                AllDishes.Add(dish);
            }
            
        }
    }
}
