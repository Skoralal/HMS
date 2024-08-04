namespace HMS.HMSModels
{
    public class HouseHold
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public List<Good> AllGoods { get; set; } = new List<Good>();
        public List<Dish> AllDishes { get; set; } = new List<Dish>();
        public List<Member> AllMembers { get; set; } = new List<Member>();
        public List<string> Shops { get; set; } = new();
        public HouseHold()
        {
            Login = string.Empty;
            Password = string.Empty;
        }
        public HouseHold(string login, string password)
        {
            this.Login = login;
            this.Password = password;
        }
        public HouseHold(string login, string password, List<Good> allGoods, List<Dish> allDishes, List<Member> allMembers)
        {
            this.Login = login;
            this.Password = password;
            this.AllGoods = allGoods;
            this.AllDishes = allDishes;
            this.AllMembers = allMembers;
        }
    }
}
