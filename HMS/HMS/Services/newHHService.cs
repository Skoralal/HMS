using HMS.Components.Account.Pages;
using HMS.Data;
using HMS.Entities;

namespace HMS.Services
{
    public class newHHService : InewHHService
    {
        private readonly ApplicationDbContext _context;
        private readonly DataService _dataService;
        public newHHService(ApplicationDbContext context, DataService dataService)
        {
            _context = context;
            _dataService = dataService; 
        }
        public async Task<HH> AddHH(HH hh, string memberLogin)
        {
            _context.HHs.Add(hh);
            _context.DBMembers.Add(new() { HouseHoldLogin = hh.Login, MemberLogin = memberLogin });
            await _context.SaveChangesAsync();
            return hh;
        }

        public async Task<HH?> GetHH(string ID)
        {
            return await _context.HHs.FindAsync(ID);
        }

        public async Task<HH?> GetHHByUserLogin(string userId)
        {
            var hhLogin = await _context.DBMembers.FindAsync(userId);
            if (hhLogin == null)
            {
                return null;
            }
            return await GetHH(hhLogin.HouseHoldLogin);
        }

        public async Task<HH> UpdateHH()
        {
            var entity = await _context.HHs.FindAsync(_dataService.currentHH.Login);
            var hh = _dataService.currentHH;
            entity = hh;//maybe assign properties and not the whole thing
            //entity!.Login = hh.Login;
            //entity.Shops = hh.Shops;
            //entity.AllGoods = hh.AllGoods;
            //entity.AllMembers = hh.AllMembers;
            //entity.Password = hh.Password;
            //entity.AllDishes = hh.AllDishes;
            await _context.SaveChangesAsync();
            return hh;
        }
    }
}
