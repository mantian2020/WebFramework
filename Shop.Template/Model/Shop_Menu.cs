using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Template.Model
{
    public class Shop_Menu
    {
        public int Shop_MenuId { set; get; }
        public string Shop_MenuName { set; get; }
        public string Shop_MenuUrl { set; get; }
        public int Shop_RoleId { set; get; }
        public int Shop_ParentId { set; get; }
    }
}
