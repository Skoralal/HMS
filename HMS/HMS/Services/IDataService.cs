using HMS.Entities;

namespace HMS.Services
{
    public interface IDataService
    {
        public Good StraightConvertCookableDBGoodGood(DBGood dBGood);
        public Good RestoreGoodFromString(string corpse, List<Good> goods);
        public Good RestoreGoodFromStringDic(string corpse, Dictionary<string, Good> goods);
    }
}
