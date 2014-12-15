using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CoreFramework.Controllers
{
    public class BasePageController:Controller
    {
        /// <summary>
        /// 项目名
        /// </summary>
        private string ProjectName;
        public BasePageController(string projectName)
        {
            this.ProjectName = projectName;
        }
        
    }
}
