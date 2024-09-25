using HMS.HMSModels;
using System.ComponentModel.DataAnnotations;

namespace HMS.Entities
{
    public class Dish
    {
        [Key]
        public string ID { get; set; } = "";//Time+Owner+Name
        public string Name { get; set; } = "";
        public bool Cooked { get; set; } = false;
        public bool Consumed { get; set; } = false ;
        public List<Good> Contents { get; set; } = new List<Good>();
        public string Time { get; set; } = "";
        public string Owner { get; set; } = "";
        public double Amount { get; set; } = 0;
        public string Recipe { get; set; } = "";
        public string Category { get; set; } = "";
        public Dish() { }

    }
}
