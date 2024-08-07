using System.Runtime.Serialization;

namespace HMS.HMSModels
{
    [DataContract]
    public class Good
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public List<Good>? Ingredients { get; set; }
        [DataMember]
        public double Stock { get; set; }
        [DataMember]
        public double? PassiveConsumption { get; set; }
        [DataMember]
        public string? Icon { get; set; }
        [DataMember]
        public string Recipe { get; set; } = "";
        public Good() { }
        public Good(string name, double stock, double? naturalDecay, string? icon)
        {
            this.Name = name;
            this.Stock = stock;
            this.PassiveConsumption = naturalDecay;
            this.Icon = icon;
        }
        public Good(string name, double stock)
        {
            this.Name = name;
            this.Stock = stock;
        }
        public Good(Good original)
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
