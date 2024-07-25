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

        public async Task<DBGood> AddHMSGood(Good Good, string OwnerHH)
        {
            DBGood converted = new();
            converted.Name = Good.Name;
            converted.Stock = Good.Stock;
            converted.Icon = Good.Icon;
            converted.PassiveConsumptionRate = Good.PassiveConsumption;
            if (Good.Ingredients != null)
            {
                converted.Ingredients = "";
                foreach (var ing in Good.Ingredients)
                {
                    converted.Ingredients += ing.Name;
                    converted.Ingredients += ":";
                    converted.Ingredients += ing.Stock.ToString();
                    converted.Ingredients += ",";//here
                }
            }
            converted.OwnerHH = OwnerHH;
            converted.Id = OwnerHH + Good.Name;
            _context.DBGoods.Add(converted);
            await _context.SaveChangesAsync();
            return converted;
        }

        public async Task<List<DBGood>> GetHHGoods(string OwnerLogin)
        {
            return _context.DBGoods.Where(x=>x.OwnerHH == OwnerLogin).ToList();
        }

        public async Task<List<string>> GetHHGoodsNames(string OwnerHH)
        {
            return _context.DBGoods.Where(x =>x.OwnerHH == OwnerHH).Select(e => e.Name).ToList();
        }
    }
}
