using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clover.Dao;
using Clover.Domain;

namespace Clover.Service.Implement
{
    public class UserInfoManager : GenericManagerBase<UserInfo>, IUserInfoManager
    {
        public IList<UserInfo> LoadAllByPage(out long total, int page, int rows, string order, string sort)
        {
            return ((IUserInfoRepository)(this.CurrentRepository))
                .LoadAllByPage(out total, page, rows, order, sort).ToList();
        }

        /// <summary>
        /// 获取MD5值
        /// </summary>
        /// <param name="key">加密的字符串</param>
        /// <returns>返回MD5值</returns>
        private string HashCode(string key)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(key, "MD5");
        }

        public override object Save(UserInfo entity)
        {
            entity.Password = this.HashCode(entity.Account.ToUpper() + "123456" + entity.CreateTime.ToLongDateString());
            return base.Save(entity);
        }

        public UserInfo Get(string account)
        {
            return ((IUserInfoRepository)(this.CurrentRepository)).Get(account);
        }

        public UserInfo Get(string account, string password)
        {
            var entity = ((IUserInfoRepository)(this.CurrentRepository)).Get(account);

            if (entity != null)
            {
                if (entity.Password !=
                        this.HashCode(entity.Account.ToUpper() + password 
                            + entity.CreateTime.ToLongDateString()))
                {
                    return null;
                }
            }

            return entity;
        }

        public void Update(UserInfo entity, string password)
        {
            entity.Password = this.HashCode(entity.Account.ToUpper() + password + entity.CreateTime.ToLongDateString());
            base.Update(entity);
        }

        public bool Login(string userName, string password)
        {
            return "admin".Equals(userName, StringComparison.InvariantCultureIgnoreCase) && "Admin@123".Equals(password, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
