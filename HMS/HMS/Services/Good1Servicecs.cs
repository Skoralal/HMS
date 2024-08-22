using HMS.Data;
using HMS.Entities;
using HMS.HMSModels;

namespace HMS.Services
{
    public class Good1Servicecs : IGood1Service
    {
        private readonly ApplicationDbContext _context;
        public Good1Servicecs(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Good1> AddGood1(Good1 good1)
        {
            foreach (var shop in good1.Ingredients)
            {
                shop.HHOwner = good1.HHOwner;
            }
            _context.Goods1.Add(good1);
            await _context.SaveChangesAsync();
            return good1;
        }

        public async Task<Good1> GetGood1(string id)
        {
            return await _context.Goods1.FindAsync(id);
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
            //converted.Name = Good.Name;
            //converted.Stock = Good.Stock;
            //converted.Icon = Good.Icon;
            //converted.PassiveConsumptionRate = Good.PassiveConsumption;
            //converted.Recipe = Good.Recipe;
            //if (Good.Ingredients != null)
            //{
            //    converted.Ingredients = "shops:";
            //    foreach (var ing in Good.Ingredients)
            //    {
            //        converted.Ingredients += ing.Name;
            //        converted.Ingredients += ";";//here
            //    }
            //}
            //converted.Ingredients = converted.Ingredients[..(converted.Ingredients.Length - 1)];
            //converted.OwnerHH = OwnerHH;
            //converted.Id = OwnerHH + Good.Name;
            //_context.DBGoods.Add(converted);
            //await _context.SaveChangesAsync();
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

       

        public async Task<List<Good1>> GetHHGoods(string OwnerLogin)
        {
            return _context.Goods1.Where(x => x.HHOwner == OwnerLogin).ToList();
        }

        public Task<List<string>> GetHHGoodsNames(string OwnerHH)
        {
            throw new NotImplementedException();
        }
    }
}
