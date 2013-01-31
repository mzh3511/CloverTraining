using System.Linq;
using System.Linq.Dynamic;
using Clover.Domain;

namespace Clover.Dao.Implement
{
    public class ForumRepository : Repository<Forum>, IForumRepository
    {
        public IQueryable<Forum> LoadAllByPage(out long total, int page, int rows, string order, string sort)
        {
            var list = this.LoadAll();

            total = list.LongCount();

            list = list.OrderBy(sort + " " + order);
            list = list.Skip((page - 1) * rows).Take(rows);

            return list;
        }

        public IQueryable<Forum> LoadAllEnable()
        {
            return from li in this.LoadAll()
                   where li.IsEnabled
                   orderby li.OrderNo descending
                   select li;
        }
    }
}
