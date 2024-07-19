using HMS.Data;
using HMS.Entities;

namespace HMS.Services
{
    public class GoodService : IGoodService
    {
        private readonly ApplicationDbContext _context;
        public GoodService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<DBGood>> GetHHGoods(string OwnerLogin)
        {
            return _context.DBGoods.Where(x=>x.OwnerHH == OwnerLogin).ToList();
        }
    }
}
