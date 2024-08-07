using HMS.Data;
using HMS.Entities;
using HMS.HMSModels;

namespace HMS.Services
{
    public class GoodService : IGoodService
    {
        private readonly ApplicationDbContext _context;
        public GoodService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DBGood> AddDBGood(DBGood dBGood)
        {
            _context.DBGoods.Add(dBGood);
            await _context.SaveChangesAsync();
            return dBGood;
        }

        public async Task<DBGood> AddHMSBoughtGood(Good Good, string OwnerHH)
        {
            DBGood converted = new();
            converted.Name = Good.Name;
            converted.Stock = Good.Stock;
            converted.Icon = Good.Icon;
            converted.PassiveConsumptionRate = Good.PassiveConsumption;
            converted.Recipe = Good.Recipe;
            if (Good.Ingredients != null)
            {
                converted.Ingredients = "shops:";
                foreach (var ing in Good.Ingredients)
                {
                    converted.Ingredients += ing.Name;
                    converted.Ingredients += ";";//here
                }
            }
            converted.Ingredients = converted.Ingredients[..(converted.Ingredients.Length - 1)];
            converted.OwnerHH = OwnerHH;
            converted.Id = OwnerHH + Good.Name;
            _context.DBGoods.Add(converted);
            await _context.SaveChangesAsync();
            return converted;
        }

        public async Task<DBGood> AddHMSGood(Good Good, string OwnerHH)
        {
            DBGood converted = new();
            converted.Name = Good.Name;
            converted.Stock = Good.Stock;
            converted.Icon = Good.Icon;
            converted.PassiveConsumptionRate = Good.PassiveConsumption;
            converted.Recipe = Good.Recipe;
            if (Good.Ingredients != null)
            {
                converted.Ingredients = "";
                foreach (var ing in Good.Ingredients)
                {
                    converted.Ingredients += ing.Name;
                    converted.Ingredients += ":";
                    converted.Ingredients += ing.Stock.ToString();
                    converted.Ingredients += ";";//here
                }
            }
            converted.Ingredients = converted.Ingredients[..(converted.Ingredients.Length - 1)];
            converted.OwnerHH = OwnerHH;
            converted.Id = OwnerHH + Good.Name;
            _context.DBGoods.Add(converted);
            await _context.SaveChangesAsync();
            return converted;
        }

        public Task<Good> GetHHConvertedGoods(string OwnerHH)
        {
            throw new NotImplementedException();
        }

        public async Task<Dictionary<string, Good>> GetHHDicGoods(string OwnerHH)
        {
            List<DBGood> dbGoods = _context.DBGoods.Where(x => x.OwnerHH == OwnerHH).ToList();
            Dictionary<string, Good> output = new();
            foreach (var good in dbGoods)
            {
                List<Good> Ings = new List<Good>();
                if (!good.Ingredients.StartsWith("shop"))
                {
                    foreach (var pair in good.Ingredients.Split(";"))
                    {
                        var splitted = pair.Split(":");
                        Ings.Add(new Good() { Name = splitted[0], Stock = Convert.ToDouble(splitted[1]) });
                    }
                }
                else
                {
                    Ings.Add(new Good() { Name = "shops" });
                    foreach (var pair in good.Ingredients[6..].Split(";"))
                    {
                        Ings.Add(new Good() { Name = pair });
                    }
                }

                output.Add(good.Name,new() { Name = good.Name, Stock = good.Stock, Icon = good.Icon, PassiveConsumption = good.PassiveConsumptionRate, Recipe = good.Recipe, Ingredients = Ings });
            }
            return output;
        }

        public async Task<List<DBGood>> GetHHGoods(string OwnerLogin)
        {
            return _context.DBGoods.Where(x=>x.OwnerHH == OwnerLogin).ToList();
        }

        public async Task<List<string>> GetHHGoodsNames(string OwnerHH)
        {
            return _context.DBGoods.Where(x =>x.OwnerHH == OwnerHH).Select(e => e.Name).ToList();
        }

        public async Task<List<Good>> GetHHSimplifiedGoods(string OwnerHH)
        {
            List<DBGood> dbGoods = _context.DBGoods.Where(x => x.OwnerHH == OwnerHH).ToList();
            List<Good> output = new();
            foreach (var good in dbGoods)
            {
                List<Good> Ings = new List<Good>();
                if (!good.Ingredients.StartsWith("shop"))
                {
                    foreach (var pair in good.Ingredients.Split(";"))
                    {
                        var splitted = pair.Split(":");
                        Ings.Add(new Good() { Name = splitted[0], Stock = Convert.ToDouble(splitted[1]) });
                    }
                }
                else
                {
                    Ings.Add(new Good() { Name = "shops" });
                    foreach (var pair in good.Ingredients[6..].Split(";"))
                    {
                        Ings.Add(new Good() { Name = pair});
                    }
                }

                output.Add(new() {Name = good.Name, Stock = good.Stock , Icon = good.Icon, PassiveConsumption = good.PassiveConsumptionRate, Recipe = good.Recipe, Ingredients = Ings});
            }
            return output;
        }
    }
}
