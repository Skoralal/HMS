using HMS.Entities;

namespace HMS.Services
{
    public interface IDishService
    {
        Task<List<DBDish>> GetAllHHDishes(string HHLogin);
    }
}
