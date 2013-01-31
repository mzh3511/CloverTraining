using System;
using System.Linq;
using Clover.Domain;

namespace Clover.Dao
{
    public interface ICategoryRepository : IRepository<Category>
    {
        IQueryable<Category> LoadAllByPage(out long total, int page, int rows, string order, string sort);

        IQueryable<Category> LoadAllEnable();

        IQueryable<Category> LoadAllEnable(Guid forumId);
    }
}
