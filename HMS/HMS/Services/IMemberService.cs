using HMS.Entities;

namespace HMS.Services
{
    public interface IMemberService
    {
        Task<DBMember> InitialMember(DBMember dBMember);
        Task<DBMember> GetMemberByLogin(string loginToSearch);
        Task<List<DBMember>> GetAllHHMembers(string hhLogin);
        Task<string> GetParentHH(string loginToSearch);
    }
}
