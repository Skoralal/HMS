using HMS.Entities;

namespace HMS.Services
{
    public interface InewHHService
    {

        Task<HH?> GetHH(string ID);
        Task<HH> AddHH(HH hh, string memberLogin);
        Task<HH> UpdateHH();
        Task<HH?> GetHHByUserLogin(string userId);
    }
}
