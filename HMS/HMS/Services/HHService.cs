using HMS.Data;
using HMS.Entities;

namespace HMS.Services
{
    public class HHService : IHHService
    {
        private readonly ApplicationDbContext _context;
        public HHService(ApplicationDbContext context)
        {
            _context = context;
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
    }
}
