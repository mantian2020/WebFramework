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
            return string.Format("{0}${1}", iSymmetricSecurity.Encrypt(user.UserName),
                iSymmetricSecurity.Encrypt(user.Code));
        }

        public override UserInfo DeserializeUserInfo(string userData)
        {
            string[] msg = userData.Split('$');

            if (2 == msg.Length)
            {
                UserInfo simpleUser = new UserInfo();

                simpleUser.UserName = iSymmetricSecurity.Decrypt(msg[0]);
                simpleUser.Code = iSymmetricSecurity.Decrypt(msg[1]);

                return simpleUser;
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
