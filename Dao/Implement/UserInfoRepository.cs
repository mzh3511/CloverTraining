using System.Linq;
using System.Linq.Dynamic;
using Clover.Domain;

namespace Clover.Dao.Implement
{
    public class UserInfoRepository : Repository<UserInfo>, IUserInfoRepository
    {
        public IQueryable<UserInfo> LoadAllByPage(out long total, int page, int rows, string order, string sort)
        {
            var list = this.LoadAll();

            total = list.LongCount();

            list = list.OrderBy(sort + " " + order);
            list = list.Skip((page - 1) * rows).Take(rows);

            return list;
        }

        public UserInfo Get(string account)
        {
            return this.LoadAll().FirstOrDefault(f => f.Account == account);
        }
    }
}
