using HMS.HMSModels;
using System.ComponentModel.DataAnnotations;

namespace HMS.Entities
{
    public class HH
    {
        [Key]
        public string Login { get; set; } = "";
        public string Password { get; set; } = "";
        public List<Good> AllGoods { get; set; } = new List<Good>();
        public List<Dish> AllDishes { get; set; } = new List<Dish>();
        public List<Member> AllMembers { get; set; } = new List<Member>();
        public List<string> Shops { get; set; } = new();
        public HH()
        {
        }
    }
}
