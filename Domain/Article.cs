using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clover.Domain
{
    public class Article
    {
        public virtual int ID { get; set; }
        public virtual string Title { get; set; }
        public virtual string Content { get; set; }
        public virtual bool IsEnabled { get; set; }
        public virtual Category Category { get; set; }
    }
}
