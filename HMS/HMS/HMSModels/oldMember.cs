namespace HMS.HMSModels
{
    public class oldMember
    {
        public string Name { get; set; }
        public List<oldDish>? Schedule { get; set; }
        public oldMember(string name)
        {
            this.Name = name;
        }
    }
}
