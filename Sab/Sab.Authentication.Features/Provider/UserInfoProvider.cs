using Sab.DataAcess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sab.Authentication.Features.Provider
{
    public interface IUserInfoProvider
    {
        public bool IsSeniorUser(string userLoginId);
    }
    public class UserInfoProvider : IUserInfoProvider
    {
        private SabDataContext _sabDataContext;
        public const int SENIOR_USER_THRSHOLD_YEAR = 1;

        public UserInfoProvider(SabDataContext sabDataContext)
        {
            this._sabDataContext = sabDataContext;
        }
        public bool IsSeniorUser(string userLoginId)
        {
            var user = this._sabDataContext.Users.First(item => item.UserName == userLoginId);

            return user.CreatedDate.AddYears(SENIOR_USER_THRSHOLD_YEAR) <= DateTime.Now;
        }
    }
}
