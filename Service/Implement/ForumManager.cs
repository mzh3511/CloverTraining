using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clover.Dao;
using Clover.Domain;

namespace Clover.Service.Implement
{
    public class ForumManager : GenericManagerBase<Forum>, IForumManager
    {
        public IList<Forum> LoadAllByPage(out long total, int page, int rows, string order, string sort)
        {
            return ((IForumRepository)(this.CurrentRepository))
                .LoadAllByPage(out total, page, rows, order, sort).ToList();
        }

        public IList<Forum> LoadAllEnable()
        {
            return ((IForumRepository)(this.CurrentRepository)).LoadAllEnable().ToList();
        }
    }
}
