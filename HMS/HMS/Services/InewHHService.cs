using HMS.Entities;

namespace HMS.Services
{
    public interface InewHHService
    {
        public string Aboba {  get; set; }
        public Good SharedGood { get; set; }
        public Dish SharedDish { get; set; }
        public HH currentHH { get; set; }
        Task<HH?> GetHH(string ID);
        Task<HH> AddHH(HH hh, string memberLogin);
        Task<HH> UpdateHH();
        Task<HH?> GetHHByUserLogin(string userId);
        public Task LoadDataFromSession();
        public Task SaveToSessionStorage();
        public string Serizlized();
        public string Cook(double amount);
        public string Buy(double amount);
    }
}
