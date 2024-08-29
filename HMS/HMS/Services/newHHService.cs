using HMS.Components.Account.Pages;
using HMS.Data;
using HMS.Entities;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.Extensions.Options;
using System.Xml.Linq;

namespace HMS.Services
{
    public class newHHService : InewHHService
    {
        private readonly ApplicationDbContext _context;
        private readonly DataService _dataService;
        public newHHService(ApplicationDbContext context, DataService dataService)
        {
            _context = context;
            _dataService = dataService; 
        }
        public async Task<HH> AddHH(HH hh, string memberLogin)
        {
            
            _context.HHs.Add(hh);
            _context.DBMembers.Add(new() { HouseHoldLogin = hh.Login, MemberLogin = memberLogin });
            await _context.SaveChangesAsync();
            return hh;
        }

        public async Task<HH?> GetHH(string ID)
        {
            HH? hh = await _context.HHs.FindAsync(ID);
            if (hh != null)
            {
                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.Preserve,
                    WriteIndented = true
                };
                Good Root = JsonSerializer.Deserialize<Good>(hh!.SerializedGoods, options)!;
                hh.AllGoods.Clear();
                foreach (var good in Root.Ingredients)
                {
                    hh.AllGoods.Add(good);
                }
            }
            return hh;
        }

        public async Task<HH?> GetHHByUserLogin(string userId)
        {
            var hhLogin = await _context.DBMembers.FindAsync(userId);
            if (hhLogin == null)
            {
                return null;
            }
            return await GetHH(hhLogin.HouseHoldLogin);
        }

        public async Task<HH> UpdateHH()
        {
            var entity = await _context.HHs.FindAsync(_dataService.currentHH.Login);
            var hh = _dataService.currentHH;
            Good Root = new Good();
            foreach (var good in hh.AllGoods)
            {
                Root.Ingredients.Add(good);
            }
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                WriteIndented = true
            };
            hh.SerializedGoods = JsonSerializer.Serialize(Root, options);
            //entity = hh;//maybe assign properties and not the whole thing
            entity!.Login = hh.Login;
            entity.Shops = hh.Shops;
            entity.AllGoods = new();
            entity.AllMembers = hh.AllMembers;
            entity.Password = hh.Password;
            entity.AllDishes = hh.AllDishes;
            entity.SerializedGoods = hh.SerializedGoods;
            await _context.SaveChangesAsync();
            return hh;
        }
    }
}
