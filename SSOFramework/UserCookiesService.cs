using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonHelper;
using CommonHelper.Security;

namespace SSOFramework
{
    public class UserCookiesService : BaseSsO<UserInfo>
    {
        private readonly string currentdomain = Config.GetAppSettings("Domain");
        private readonly string currentMinutes =  Config.GetAppSettings("ExpiresMinutes");
        //创建对称加密接口
        private ISymmetricSecurity iSymmetricSecurity = SecurityFactory.CreateSymmetricSecurity();

        public UserCookiesService()
        {
            this.Domain = currentdomain;
            this.ExpiresMinutes = int.Parse(currentMinutes);
        }

        public override string SerializeUserInfo(UserInfo user)
        {
            return iSymmetricSecurity.Encrypt(SerializeHelper.SerializeData<UserInfo>(user));
        }

        public override UserInfo DeserializeUserInfo(string userData)
        {
            string[] msg = userData.Split('$');

            if (!string.IsNullOrEmpty(userData))
            {
                return SerializeHelper.Deserialize<UserInfo>(iSymmetricSecurity.Decrypt(userData));
            }
            else
            {
                return null;
            }
        }

        public override string GetUserAccount(UserInfo user)
        {
            return user.UserName;
        }
    }
}
