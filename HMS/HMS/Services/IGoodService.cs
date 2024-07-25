﻿using HMS.Entities;
using HMS.HMSModels;

namespace HMS.Services
{
    public interface IGoodService
    {
        Task<List<DBGood>> GetHHGoods(string id);
        Task<DBGood> AddDBGood(DBGood dBGood);
        Task<DBGood> AddHMSGood(Good Good, string OwnerHH);
        Task<List<string>> GetHHGoodsNames(string OwnerHH);

    }
}
