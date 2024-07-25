using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace HMS.Entities
{
    public class DBGood
    {
        [Key]
        public string Id { get; set; } //should be OwnerHH + Name
        public string OwnerHH {  get; set; }
        public string Name { get; set; }
        public string? Ingredients { get; set; } // example: "Wheat:10,Milk:1,Egg:2" read string, then split.
        public double? Stock { get; set; }
        public double? PassiveConsumptionRate { get; set; } // how many per day
        public string? Icon { get; set; }
        public DBGood(string name, double? stock, double? PassiveConsumptionRate, string? icon, string ownerHH)
        {
            this.Name = name;
            this.Stock = stock;
            this.PassiveConsumptionRate = PassiveConsumptionRate;
            this.Icon = icon;
            OwnerHH = ownerHH;
        }
        public DBGood() { }
    }
}
