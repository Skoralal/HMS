using HMS.Entities;

namespace HMS.Services
{
    public interface IDishService
    {
        Task<List<DBDish>> GetAllHHDishes(string HHLogin);
        Task<DBDish> AddNewDBDish(DBDish dbDish);
        Task<HashSet<string>> GetHHCategories(string HHLogin);
        Task<List<DBDish>> GetTemplateHHDishes(string HHLogin);
        Task<List<DBDish>> GetDateHHDishes(string HHLogin, string date);
        Task<DBDish> GetDBDishByID(string id);
    }
}
