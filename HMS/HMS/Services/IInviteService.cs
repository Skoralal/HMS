using HMS.Entities;

namespace HMS.Services
{
    public interface IInviteService
    {
        Task<List<Invite>> GetAllInvites();
    }
}
