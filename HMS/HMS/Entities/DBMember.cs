using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace HMS.Entities
{
    public class DBMember
    {
        public string HouseHoldLogin {  get; set; }
        [Key]
        public string MemberLogin { get; set; }
        //public DBMember(string HHLogin, string MemberLogin)
        //{
        //    HouseHoldLogin = HHLogin;
        //    this.MemberLogin = MemberLogin;
        //}
    }
    
}
