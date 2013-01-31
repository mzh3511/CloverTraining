﻿using System.Linq;
using Clover.Domain;

namespace Clover.Dao
{
    public interface IUserInfoRepository : IRepository<UserInfo>
    {
        IQueryable<UserInfo> LoadAllByPage(out long total, int page, int rows, string order, string sort);

        UserInfo Get(string account);
    }
}
