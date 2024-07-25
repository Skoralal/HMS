using HMS.Data;
using HMS.Entities;

namespace HMS.Services
{
    public class InviteService : IInviteService
    {
        private readonly ApplicationDbContext _context;
        public InviteService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<List<Invite>> GetAllInvites()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Invite>> GetMyInvites(string recieverUser)
        {
            return _context.Invites.Where(x => x.Reciever == recieverUser).ToList();
        }

        public async Task<Invite> SendInvite(Invite invite)
        {
            _context.Invites.Add(invite);
            await _context.SaveChangesAsync();
            return invite;
        }
    }
}
