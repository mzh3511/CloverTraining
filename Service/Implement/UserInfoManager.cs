using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clover.Dao;
using Clover.Domain;

namespace Clover.Service.Implement
{
    public class UserInfoManager : IUserInfoManager
    {
        public bool Login(string userName, string password)
        {
            return "admin".Equals(userName, StringComparison.InvariantCultureIgnoreCase) && "Admin@123".Equals(password);
        }
    }
}
