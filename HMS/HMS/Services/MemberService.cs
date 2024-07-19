using HMS.Data;
using HMS.Entities;

namespace HMS.Services
{
    public class MemberService : IMemberService
    {
        private readonly ApplicationDbContext _context;
        public MemberService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<DBMember>> GetAllHHMembers(string hhLogin)
        {
            return _context.DBMembers.Where(x => x.HouseHoldLogin == hhLogin).ToList();
        }

        public async Task<DBMember> GetMemberByLogin(string loginToSearch)
        {
            return _context.DBMembers.Find(loginToSearch);
        }

        public async Task<string> GetParentHH(string loginToSearch)
        {
            var aboba =  await _context.DBMembers.FindAsync(loginToSearch);
            if (aboba == null)
            {
                return null;
            }
            return aboba.HouseHoldLogin;
        }

        public async Task<DBMember> InitialMember(DBMember dBMember)
        {
            _context.DBMembers.Add(dBMember);
            //DBMember aboba = new DBMember(HH.Login, UserLogin);
            //_context.DBMembers.Add(aboba);
            await _context.SaveChangesAsync();
            return dBMember;
        }

        Task<List<DBMember>> IMemberService.GetAllHHMembers(string hhLogin)
        {
            throw new NotImplementedException();
        }
    }
}
