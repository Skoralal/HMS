using HMS.Components.Account.Pages;
using HMS.Data;
using HMS.Entities;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.Extensions.Options;
using System.Xml.Linq;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using HMS.Migrations;
using Microsoft.AspNetCore.Identity.UI.Services;
using HMS.HMSModels;

namespace HMS.Services
{
    public class newHHService : InewHHService
    {
        private readonly ApplicationDbContext _context;
        private readonly ProtectedSessionStorage _sessionStorage;
        public newHHService(ApplicationDbContext context, ProtectedSessionStorage sessionStorage)
        {
            _context = context;
            _sessionStorage = sessionStorage;
            //LoadDataFromSession().GetAwaiter().GetResult();
        }
        
        public string Aboba { get; set; } = "shmee";

        public Good SharedGood { get; set; } = new Good();
        public Dish SharedDish { get; set; } = new Dish();

        public HH currentHH { get; set; } = new HH();
        private JsonSerializerOptions options = new JsonSerializerOptions
        {
            ReferenceHandler = ReferenceHandler.Preserve,
            WriteIndented = true
        };
        public async Task LoadDataFromSession()
        {
            var result = await _sessionStorage.GetAsync<string>("currentHH");
            if (result.Success)
            {
                currentHH = JsonSerializer.Deserialize<HH>(result.Value, options);
            }
            result = await _sessionStorage.GetAsync<string>("SharedDish");
            if (result.Success)
            {
                SharedDish = JsonSerializer.Deserialize<Dish>(result.Value, options);
            }
            result = await _sessionStorage.GetAsync<string>("SharedGood");
            if (result.Success)
            {
                SharedGood = JsonSerializer.Deserialize<Good>(result.Value, options);
            }
        }
        public async Task SaveToSessionStorage()
        {
            await _sessionStorage.SetAsync("currentHH", this.Serizlized());
            await _sessionStorage.SetAsync("SharedDish", JsonSerializer.Serialize(SharedDish, options));
            await _sessionStorage.SetAsync("SharedGood", JsonSerializer.Serialize(SharedGood, options));
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
            HH? hh = new(await _context.HHs.FindAsync(ID));
            if (hh != null)
            {
                if (hh.SerializedGoods.Length > 0)
                {
                    List<Good> Root = JsonSerializer.Deserialize<List<Good>>(hh!.SerializedGoods, options)!;
                    hh.GoodsDic.Clear();
                    foreach (var good in Root)
                    {
                        hh.AddGood(good);
                    }
                }
                if (hh.SerializedDish.Length > 0)
                {
                    List<Dish> Root = JsonSerializer.Deserialize<List<Dish>>(hh!.SerializedDish, options)!;
                    foreach (var dish in Root)
                    {
                        hh.AddDish(dish);
                    }
                }
                if (hh.SerializedMember.Length > 0)
                {
                    List<Member> Root = JsonSerializer.Deserialize<List<Member>>(hh!.SerializedMember, options)!;
                    foreach (var member in Root)
                    {
                        hh.AllMembers.Add(member);
                    }
                }
                if (hh.SerializedNormalizedGoods.Length > 0)
                {
                    List<Good> Root = JsonSerializer.Deserialize<List<Good>>(hh!.SerializedNormalizedGoods, options)!;
                    foreach (var good in Root)
                    {
                        hh.AddNormalizedGood(good);
                    }
                }
            }
            hh.SerializedDish = "";
            hh.SerializedGoods = "";
            hh.SerializedNormalizedGoods = "";
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
            var entity = await _context.HHs.FindAsync(currentHH.Login);
            var hh = currentHH;
            List<Dish> dishes = new List<Dish>();
            List<Member> Members = new List<Member>();
            
            List<Good> goods = new List<Good>();
            List<Good> normalGoods = new List<Good>();
            foreach (var good in hh.GoodsDic.Values)
            {
                goods.Add(good);
            }
            foreach (var dish in hh.DishesDic)
            {
                dishes.Add(dish.Value);
            }
            foreach (var item in hh.AllMembers)
            {
                Members.Add(item);
            }
            foreach(var normalGood in hh.NormalizedGoodsDic.Values)
            {
                normalGoods.Add(normalGood);
            }
            //hh.SerializedGoods = JsonSerializer.Serialize(Root, options);
            hh.SerializedGoods = JsonSerializer.Serialize(goods, options);
            hh.SerializedDish = JsonSerializer.Serialize(dishes, options);
            hh.SerializedMember = JsonSerializer.Serialize(Members, options);
            hh.SerializedNormalizedGoods = JsonSerializer.Serialize(normalGoods, options);
            //entity = hh;//maybe assign properties and not the whole thing
            entity!.Login = hh.Login;
            entity.Shops = hh.Shops;
            entity.Password = hh.Password;
            entity.SerializedGoods = hh.SerializedGoods;
            entity.SerializedNormalizedGoods = hh.SerializedNormalizedGoods;
            entity.SerializedDish = hh.SerializedDish;
            await _context.SaveChangesAsync();
            await SaveToSessionStorage();
            return hh;
        }

        public string Serizlized()
        {
            string output = "";
            output = JsonSerializer.Serialize(currentHH, options);
            return output;
        }
        public string Cook(double amount)
        {
            string name = this.SharedGood.Name;
            Good goodToCook = currentHH.GoodsDic[name];
            foreach(var ing in goodToCook.Ingredients)
            {
                if (this.currentHH.GoodsDic[ing.Name].Stock - amount * currentHH.NormalizedGoodsDic[name].Ingredients
                                        .Where(x=>x.Name==ing.Name).First().Stock < 0)
                {
                    return "nope";
                }
            }
            foreach(var ing in goodToCook.Ingredients)
            {
                this.currentHH.GoodsDic[ing.Name].Stock -= amount * currentHH.NormalizedGoodsDic[name].Ingredients
                                        .Where(x => x.Name == ing.Name).First().Stock;
            }
            goodToCook.Stock += amount;
            return "yes";
        }
        public string Buy(double amount)
        {
            string name = this.SharedGood.Name;
            this.currentHH.GoodsDic[name].Stock += amount;
            return $"Bought {amount} of {this.SharedGood.Name}";
        }
    }
}
