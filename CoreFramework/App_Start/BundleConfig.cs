using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Optimization;

namespace CoreFramework
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bootstrap/css")
                .Include("~/bootstrap/css/bootstrap.min.css"
                , "~/bootstrap/css/bootstrap-responsive.min.css"
                , "~/bootstrap/css/matrix-style.css"
                , "~/bootstrap/css/matrix-media.css"
                , "~/bootstrap/font-awesome/css/font-awesome.css"));
            
            bundles.Add(new ScriptBundle("~/bootstrap/js")
                .Include("~/bootstrap/js/excanvas.min.js"
                , "~/bootstrap/js/jquery.ui.custom.js"
                , "~/bootstrap/js/bootstrap.min.js"
                , "~/bootstrap/js/matrix.js"));
            bundles.Add(new ScriptBundle("~/bootstrap/js/jquery").Include("~/bootstrap/js/jquery.min.js"));
            bundles.Add(new ScriptBundle("~/bootstrap/js/paginator").Include("~/bootstrap/js/bootstrap-paginator.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Modules/Template/MenuHelper").Include("~/Scripts/Modules/Template/MenuHelper.js"));


            /*bundles使用：
             * @Scripts.Render("~/Scripts/Modules/Template/MenuHelper")
             * @Styles.Render("~/Content/css")
             * 合并请求2种方法：
             * 1.<compilation debug="false" targetFramework="4.5"/>
             * 2.在BundleConfig中的方法末尾添加  BundleTable.EnableOptimizations = true;
             * 注:默认情况下 BundleTable.Bundles会过滤掉后缀名为这些的文件,intellisense.js、-vsdoc.js、.debug.js、.min.js、.min.css,
             * 当加载后缀名为这些的文件，将显示空白。
             * 可以用如下方法去除对这些文件过滤限制
             * BundleTable.Bundles.IgnoreList.Clear();  
             * BundleTable.Bundles.IgnoreList.Ignore(".min.js", OptimizationMode.Always); 
             * BundleTable.Bundles.IgnoreList.Ignore("-vsdoc.js", OptimizationMode.Always);
             * BundleTable.Bundles.IgnoreList.Ignore(".debug.js", OptimizationMode.Always); 
             * **/
        }
    }
}
