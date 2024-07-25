using HMS.Entities;

namespace HMS.Services
{
    public interface IInviteService
    {
        Task<List<Invite>> GetAllInvites();
        Task<List<Invite>> GetMyInvites(string recieverUser);
        Task<Invite> SendInvite(Invite invite);
    }
}
