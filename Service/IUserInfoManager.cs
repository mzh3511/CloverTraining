using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clover.Domain;

namespace Clover.Service
{
    public interface IUserInfoManager 
    {
        bool Login(string userName, string password);
    }
}
