using HMS.HMSModels;
using System.ComponentModel.DataAnnotations;

namespace HMS.Entities
{
    public class Good
    {
        [Key]
        public string Name { get; set; } = "";
        public List<Good> Ingredients { get; set; } = new();
        public double Stock { get; set; } = 0;
        public double PassiveConsumption { get; set; } = 0;
        public string Icon { get; set; } = "default";
        public string Recipe { get; set; } = "";
        public Good() { }
        public Good(Good good)
        {
            Name = good.Name;
            Ingredients = good.Ingredients;
            Stock = good.Stock;
            PassiveConsumption = good.PassiveConsumption;
            Icon = good.Icon;
            Recipe = good.Recipe;
        }
        
        

    }
}
