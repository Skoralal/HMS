namespace HMS.HMSModels
{
    public class Good
    {
        public string Name { get; set; }
        public List<Good>? Ingredients { get; set; }
        public double? Stock { get; set; }
        public double? PassiveConsumption { get; set; }
        public string? Icon { get; set; }
        public Good() { }
        public Good(string name, double? stock, double? naturalDecay, string? icon)
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
    }
}
