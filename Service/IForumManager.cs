using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clover.Domain;

namespace Clover.Service
{
    public interface IForumManager : IGenericManager<Forum>
    {
        IList<Forum> LoadAllByPage(out long total, int page, int rows, string order, string sort);

        IList<Forum> LoadAllEnable();
    }
}
