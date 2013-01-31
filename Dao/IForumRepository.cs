using System.Linq;
using Clover.Domain;

namespace Clover.Dao
{
    public interface IForumRepository : IRepository<Forum>
    {
        IQueryable<Forum> LoadAllByPage(out long total, int page, int rows, string order, string sort);

        IQueryable<Forum> LoadAllEnable();
    }
}
