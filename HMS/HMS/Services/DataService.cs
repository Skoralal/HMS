using HMS.Data;
using HMS.Entities;
using HMS.HMSModels;
using Microsoft.EntityFrameworkCore;

namespace HMS.Services
{
    public class DataService
    {
        public DBDish SharedDish { get; set; }
        public HH currentHH { get; set; }
        public Good StraightConvertCookableDBGoodGood(DBGood dBGood)
        {
            List<Good> ings = new();
            foreach(var pair in dBGood.Ingredients.Split(";"))
            {
                var pair2 = pair.Split(":");
                ings.Add(new Good() {Name = pair2[0], Stock = Convert.ToDouble(pair2[1]) });
            }
            return new Good() { Stock = dBGood.Stock, Icon = dBGood.Icon, Name = dBGood.Name,/* PassiveConsumption = dBGood.PassiveConsumptionRate,*/ Recipe = dBGood.Recipe, Ingredients = ings};
        }
        public Good RestoreGoodFromString(string corpse, List<Good> goods)
        {
            var pair = corpse.Split(":");
            List<Good> ings = new();
            foreach(var aboba in goods.Where(x=>x.Name == pair[0]).First().Ingredients)
            {
                ings.Add(new() { Name = aboba.Name, Stock = aboba.Stock * Convert.ToDouble( pair[1]) });
            }
            return new Good() { Name = pair[0], Stock = Convert.ToDouble(pair[1]), Ingredients = ings};
        }
        public Good RestoreGoodFromStringDic(string corpse, Dictionary<string, Good> goods)
        {
            var pair = corpse.Split(":");
            List<Good> ings = new();
            foreach (var aboba in goods[pair[0]].Ingredients)
            {
                ings.Add(new() { Name = aboba.Name, Stock = aboba.Stock * Convert.ToDouble(pair[1]) });
            }
            return new Good() { Name = pair[0], Stock = Convert.ToDouble(pair[1]), Ingredients = ings };
        }
        
    }
}
