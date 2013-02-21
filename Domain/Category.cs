using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clover.Domain
{
    public class Category
    {
        public virtual int ID { get; set; }
        public virtual bool IsSystem { get; set; }
        public virtual string MenuText { get; set; }
        public virtual int MenuPriority { get; set; }
        public virtual IList<Category> SubCategories { get; set; }
        public virtual Article Article { get; set; }
    }
}
