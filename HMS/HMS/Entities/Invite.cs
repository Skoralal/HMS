using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace HMS.Entities
{
    public class Invite
    {
        [Key]
        public string Id { get; set; } // SenderHH + Reciever
        public string Sender { get; set; }
        public string SenderHH { get; set; }
        public string Reciever { get; set; }

    }
}
