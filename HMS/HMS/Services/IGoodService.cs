using HMS.Entities;

namespace HMS.Services
{
    public interface IGoodService
    {
        Task<List<DBGood>> GetHHGoods(string id);

    }
}
