using System.ComponentModel.DataAnnotations;

namespace HMS.Entities
{
    public class DBHH
    {
        [Key]
        public string Login { get; set; } = "";
        public string Password { get; set; } = "";
        public string SerializedGoods { get; set; } = "";
        public string SerializedNormalizedGoods { get; set; } = "";
        public string SerializedDish { get; set; } = "";
        public string SerializedMember { get; set; } = "";
        public List<string> Shops { get; set; } = new();
        public DBHH() { }
    }
}
