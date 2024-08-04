using HMS.HMSModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace HMS.Entities
{
    public class DBDish
    {
        [Key]
        public string Id { get; set; } // HHLogin+MemberLogin+Time+Name
        public string Name { get; set; } 
        public bool Cooked { get; set; } = false; // used to be without default value
        public bool Consumed { get; set; } = false; //is it consumed
        public string Good { get; set; } //example: "Wheat:10,Milk:1,Egg:2" read string, then split.
        public string Time { get; set; } //when expected to be consumed. Maybe possible to present as DateTime object
        public string HHOwner { get; set; }
        public string MemberOwner { get; set; }
        public double Amount { get; set; } = 1; // watch out it is a string
        public string Recipe { get; set; } = "";
        public string Category { get; set; }


        public DBDish() { }
    }
}
