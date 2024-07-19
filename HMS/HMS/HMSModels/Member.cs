namespace HMS.HMSModels
{
    public class Member
    {
        public string Name { get; set; }
        public List<Dish>? Schedule { get; set; }
        public Member(string name)
        {
            this.Name = name;
        }
    }
}
