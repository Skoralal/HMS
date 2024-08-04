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

        public async Task<List<DBDish>> GetDateHHDishes(string HHLogin, string date)
        {
            return _context.DBDishes.Where(x => x.HHOwner == HHLogin).Where(x => x.Time.StartsWith(date)).ToList();
        }

        public async Task<DBDish> GetDBDishByID(string id)
        {
            return await _context.DBDishes.FindAsync(id);
        }

        public async Task<HashSet<string>> GetHHCategories(string HHLogin)
        {
            return new HashSet<string>(_context.DBDishes.Where(x => x.HHOwner == HHLogin).Select(e => e.Category).ToList());
        }

        public async Task<List<DBDish>> GetTemplateHHDishes(string HHLogin)
        {
            return _context.DBDishes.Where(x => x.HHOwner == HHLogin).Where(x => x.Time == "Template").ToList();
        }
    }
}
