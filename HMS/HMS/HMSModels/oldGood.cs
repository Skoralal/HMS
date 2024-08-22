using System.Runtime.Serialization;

namespace HMS.HMSModels
{
    public class oldGood
    {
        public string Name { get; set; }
        public List<oldGood>? Ingredients { get; set; }
        public double Stock { get; set; }
        public double? PassiveConsumption { get; set; }
        public string? Icon { get; set; }
        public string Recipe { get; set; } = "";
        public oldGood() { }
        public oldGood(string name, double stock, double? naturalDecay, string? icon)
        {
            this.Name = name;
            this.Stock = stock;
            this.PassiveConsumption = naturalDecay;
            this.Icon = icon;
        }
        public oldGood(string name, double stock)
        {
            this.Name = name;
            this.Stock = stock;
        }
        public oldGood(oldGood original)
        {
            this.Name = original.Name;
            this.Stock = original.Stock;
            this.Icon= original.Icon;
            this.Recipe = original.Recipe;
            this.Ingredients = original.Ingredients;
            this.PassiveConsumption= original.PassiveConsumption;
        }
    }
}
