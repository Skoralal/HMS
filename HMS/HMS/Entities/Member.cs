using System.ComponentModel.DataAnnotations;

namespace HMS.Entities
{
    public class Member
    {
        [Key]
        public string Login {  get; set; } = "";
        public string Name { get; set; } = "";
        public List<Dish>? Schedule { get; set; } = new();
        public Member()
        {} 
    }
}
