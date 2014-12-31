using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Template.Model
{
    public class Shop_UserInfo
    {
        public int Shop_UserId { set; get; }
        public string Shop_UserName { set; get; }
        public string Shop_UserPassword { set; get; }
        public DateTime Shop_UserCreateTime { set; get; }
        public string Shop_UserCreator { set; get; }
        public int Shop_UserVaild { set; get; }
        public long Shop_UserRoleList { set; get; }

    }
}
