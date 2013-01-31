using System;
using System.Linq;
using System.Linq.Dynamic;
using Clover.Domain;

namespace Clover.Dao.Implement
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public IQueryable<Category> LoadAllByPage(out long total, int page, int rows, string order, string sort)
        {
            var list = this.LoadAll();

            total = list.LongCount();

            list = list.OrderBy(sort + " " + order);
            list = list.Skip((page - 1) * rows).Take(rows);

            return list;
        }

        public IQueryable<Category> LoadAllEnable()
        {
            return from li in this.LoadAll()
                   where li.Forum.IsEnabled && li.IsEnabled
                   orderby li.Forum.OrderNo descending
                   orderby li.OrderNo descending
                   select li;
        }

        public IQueryable<Category> LoadAllEnable(Guid forumId)
        {
            return from li in this.LoadAll()
                   where li.Forum.ID == forumId && li.Forum.IsEnabled && li.IsEnabled
                   orderby li.Forum.OrderNo descending
                   orderby li.OrderNo descending
                   select li;
        }
    }
}
