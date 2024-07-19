namespace HMS.HMSModels
{
    public class Dish
    {
        public bool Cooked { get; set; }
        public bool Consumed { get; set; }
        public List<Good> Contents { get; set; } = new List<Good>();
        public string Time { get; set; }
        public string Owner { get; set; }
        public string Amount { get; set; }
        public Dish() { }
        public Dish(bool cooked, bool consumed, List<Good> good, string time, string owner, string amount)
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
