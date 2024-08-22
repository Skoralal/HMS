using HMS.Data;
using HMS.Entities;

namespace HMS.Services
{
    public class oldHHService : oldIHHService
    {
        private readonly ApplicationDbContext _context;
        public oldHHService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> AddShop(string HHLogin, string shopName)
        {
            var entity = _context.DBHouseHolds.Find(HHLogin);
            entity.Shops += ";" + shopName;
            await _context.SaveChangesAsync();
            return shopName;
        }

        public async Task<DBHouseHold> CreateHH(DBHouseHold HH)
        {
            HH.Admin = true;
            _context.DBHouseHolds.Add(HH);
            //DBMember aboba = new DBMember(HH.Login, UserLogin);
            //_context.DBMembers.Add(aboba);
            await _context.SaveChangesAsync();
            return HH;
        }

        public async Task<DBHouseHold> GetHHByID(string LoginToSearch)
        {
            return await _context.DBHouseHolds.FindAsync(LoginToSearch);
        }

        public async Task<List<string>> GetHHShops(string LoginToSearch)
        {
            var aboba = _context.DBHouseHolds.Find(LoginToSearch);
            return aboba.Shops[1..].Split(";").ToList();
            //return _context.DBHouseHolds.Where(x => x.Login == LoginToSearch).Select(e => e.Shops).ToString().Split(";").ToList();
        }
    }
}
