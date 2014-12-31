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
        public int Shop_MenuCode { set; get; }
        public int Shop_ParentId { set; get; }
        public DateTime Shop_MenuCreateTime { set; get; }
        public string Shop_MenuCreator { set; get; }
        public string Shop_MenuIcon { set; get; }
        public int Shop_MenuVaild { set; get; }
        public int Shop_MenuSort { set; get; }
        public int Shop_ModuleId { set; get; }
    }
}
