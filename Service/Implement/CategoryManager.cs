using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clover.Dao;
using Clover.Domain;

namespace Clover.Service.Implement
{
    public class CategoryManager : GenericManagerBase<Category>, ICategoryManager
    {
        public IList<Category> LoadAllByPage(out long total, int page, int rows, string order, string sort)
        {
            return ((ICategoryRepository)(this.CurrentRepository))
                .LoadAllByPage(out total, page, rows, order, sort).ToList();
        }

        public IList<Category> LoadAllEnable()
        {
            return ((ICategoryRepository)(this.CurrentRepository)).LoadAllEnable().ToList();
        }

        public IList<Category> LoadAllEnable(Guid forumId)
        {
            return ((ICategoryRepository)(this.CurrentRepository)).LoadAllEnable(forumId).ToList();
        }
    }
}
