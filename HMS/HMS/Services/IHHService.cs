using HMS.Entities;

namespace HMS.Services
{
    public interface IHHService
    {
        Task<DBHouseHold> CreateHH(DBHouseHold dBHH);
        Task<DBHouseHold> GetHHByID(string LoginToSearch);
        Task<List<string>> GetHHShops(string LoginToSearch);
        Task<string> AddShop(string HHLogin, string shopName);
    }
}
