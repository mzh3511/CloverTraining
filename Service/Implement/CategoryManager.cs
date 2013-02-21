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
        public IList<Category> GetSysCategory()
        {
            var query = from category in this.LoadAll()
                        where category.IsSystem
                        orderby category.MenuPriority descending
                        select category;
            return query.ToList();
        }
    }
}
