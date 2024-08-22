namespace HMS.HMSModels
{
    public class HouseHold
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public List<oldGood> AllGoods { get; set; } = new List<oldGood>();
        public List<oldDish> AllDishes { get; set; } = new List<oldDish>();
        public List<oldMember> AllMembers { get; set; } = new List<oldMember>();
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
        public HouseHold(string login, string password, List<oldGood> allGoods, List<oldDish> allDishes, List<oldMember> allMembers)
        {
            this.Login = login;
            this.Password = password;
            this.AllGoods = allGoods;
            this.AllDishes = allDishes;
            this.AllMembers = allMembers;
        }
    }
}
