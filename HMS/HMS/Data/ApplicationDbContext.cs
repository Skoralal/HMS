using HMS.Entities;
using HMS.HMSModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HMS.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<DBGood> DBGoods {  get; set; }
        public DbSet<DBDish> DBDishes {  get; set; }
        public DbSet<DBHouseHold> DBHouseHolds {  get; set; }
        public DbSet<DBMember> DBMembers {  get; set; }
        public DbSet<Invite> Invites {  get; set; }
        public DbSet<Good1> Goods1 {  get; set; }
        public DbSet<HH> HHs {  get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            // Other configurations...
        }
    }
}
