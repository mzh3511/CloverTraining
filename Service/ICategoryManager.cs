using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clover.Domain;

namespace Clover.Service
{
    public interface ICategoryManager : IGenericManager<Category>
    {
        IList<Category> GetSysCategory();
    }
}
