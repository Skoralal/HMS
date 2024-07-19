using HMS.Entities;

namespace HMS.Services
{
    public interface IHHService
    {
        Task<DBHouseHold> CreateHH(DBHouseHold dBHH);
        Task<DBHouseHold> GetHHByID(string LoginToSearch);
    }
}
