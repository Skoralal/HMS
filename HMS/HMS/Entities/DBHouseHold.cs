using System.ComponentModel.DataAnnotations;

namespace HMS.Entities
{
    public class DBHouseHold
    {
        [Key]
        public string Login { get; set; }
        public bool Admin { get; set; }
        public string Shops { get; set; } = "";
    }
}
