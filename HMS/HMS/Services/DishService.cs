using HMS.Data;
using HMS.Entities;
using HMS.HMSModels;

namespace HMS.Services
{
    public class DishService : IDishService
    {
        private readonly ApplicationDbContext _context;
        public DishService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DBDish> AddNewDBDish(DBDish dbDish)
        {
            _context.DBDishes.Add(dbDish);
            await _context.SaveChangesAsync();
            return dbDish;
        }

        public async Task<List<DBDish>> GetAllHHDishes(string HHLogin)
        {
            return _context.DBDishes.Where(x => x.HHOwner == HHLogin).ToList();
        }
    }
}
