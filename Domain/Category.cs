using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clover.Domain
{
    public class Category
    {
        private IList<Category> _SubCategories;
        public virtual int ID { get; set; }
        public virtual bool IsSystem { get; set; }
        private bool _IsEnabled = true;
        public virtual bool IsEnabled { get { return _IsEnabled; } set { _IsEnabled = value; } }
        public virtual string MenuText { get; set; }
        public virtual int MenuPriority { get; set; }
        public virtual IList<Category> SubCategories
        {
            get { return _SubCategories ?? (_SubCategories = new List<Category>()); }
            set { _SubCategories = value; }
        }
        public virtual Category ParentCategory { get; set; }
        public virtual Article Article { get; set; }

    }
}
