using System.Runtime.Serialization;

namespace HMS.HMSModels
{
    public class Good1
    {
        public string ID {  get; set; }
        public string Name { get; set; }
        public string HHOwner {  get; set; }
        public List<Good1>? Ingredients { get; set; } = new();
        public double Stock { get; set; }
        public double? PassiveConsumption { get; set; }
        public string? Icon { get; set; }
        public string Recipe { get; set; } = "";
        public Good1() { }
        public Good1(string name, double stock, double? naturalDecay, string? icon)
        {
            this.Name = name;
            this.Stock = stock;
            this.PassiveConsumption = naturalDecay;
            this.Icon = icon;
        }
        public Good1(string name, double stock)
        {
            this.Name = name;
            this.Stock = stock;
        }
        public static implicit operator Good1(Good original) 
        {
            var @this = new Good1();
            @this.Name = original.Name;
            @this.Stock = original.Stock;
            @this.Icon = original.Icon;
            @this.Recipe = original.Recipe;
            @this.PassiveConsumption = original.PassiveConsumption;
            return @this;
        }
        public Good1(Good good)
        {
            foreach(var item in good.Ingredients)
            {
                Ingredients.Add(new Good1(item));
            }
        }

    }
}
