using HMS.HMSModels;
using System.ComponentModel.DataAnnotations;

namespace HMS.Entities
{
    public class HH//inherit from dbhh(does not have transformed goods, dishes...)
    {
        [Key]
        public string Login { get; set; } = "";
        public string Password { get; set; } = "";
        public List<Good> AllGoods { get; set; } = new List<Good>();
        public string SerializedGoods { get; set; } = "";
        public List<Dish> AllDishes { get; set; } = new List<Dish>();
        public string SerializedDish { get; set; } = "";
        public List<Member> AllMembers { get; set; } = new List<Member>();
        public string SerializedMember { get; set; } = "";
        public List<string> Shops { get; set; } = new();
        public HH()
        {
        }
    }
}
