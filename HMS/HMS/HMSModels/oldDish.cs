namespace HMS.HMSModels
{
    public class oldDish
    {
        public bool Cooked { get; set; }
        public bool Consumed { get; set; }
        public List<oldGood> Contents { get; set; } = new List<oldGood>();
        public string Time { get; set; }
        public string Owner { get; set; }
        public double Amount { get; set; }
        public string Recipe { get; set; }
        public string Category { get; set; }
        public oldDish() { }
        public oldDish(bool cooked, bool consumed, List<oldGood> good, string time, string owner, double amount)
        {
            this.Cooked = cooked;
            this.Consumed = consumed;
            this.Contents = good;
            this.Time = time;
            this.Owner = owner;
            this.Amount = amount;
        }

    }
}
