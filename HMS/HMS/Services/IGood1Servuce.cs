using HMS.Entities;
using HMS.HMSModels;

namespace HMS.Services
{
    public interface IGood1Service
    {
        Task<Good1> GetGood1(string id);
        Task<Good1> AddGood1(Good1 good1);
        Task<List<Good1>> GetHHGoods(string id);
        Task<List<string>> GetHHGoodsNames(string OwnerHH);
    }
}