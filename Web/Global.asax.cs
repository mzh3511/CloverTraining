using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Text;
using Spring.Context;
using Spring.Context.Support;
using Clover.Service;

namespace Clover.Web
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : Spring.Web.Mvc.SpringMvcApplication
    {
        private static Common.Logging.ILog logger = Common.Logging.LogManager.GetLogger(typeof (MvcApplication));

        protected void Application_Start(object sender, EventArgs e)
        {
            logger.Info("日志测试");
            ControllerBuilder.Current.SetControllerFactory(typeof(Controllers.SpringControllerFactory));

            ////初始化log4net
            //log4net.Config.XmlConfigurator.Configure();

            //base.Application_Start(sender, e);
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleTable.EnableOptimizations = true;
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //this.SetInitAccount();
        }

        /// <summary>
        /// 设置初始账号
        /// </summary>
        private void SetInitAccount()
        {
            while(!ContextRegistry.IsContextRegistered("spring.root"))
            {
                System.Threading.Thread.Sleep(500);
            }



            IApplicationContext cxt = ContextRegistry.GetContext();
            IUserInfoManager manger = (IUserInfoManager)cxt.GetObject("Manager.UserInfo");

            const string account = "admin";
            var user = manger.Get(account);
            if (user == null)
            {
                user = new Domain.UserInfo
                {
                    Account = account,
                    Name = "管理员",
                    ID = Guid.NewGuid(),
                    CreateTime = DateTime.Now,
                    IsEnabled = true
                };

                manger.Save(user);
            }
        }

        protected void RegisterRoutes(RouteCollection routes)
        {
            var guidRegx = @"^\w{8}-(\w{4}-){3}\w{12}$";

            routes.MapRoute(
                "Admin", // 路由名称
                "Admin", // 带有参数的 URL
                new { controller = "Home", action = "Admin" } // 参数默认值
            );

            routes.MapRoute(
                "LogOn", // 路由名称
                "LogOn", // 带有参数的 URL
                new { controller = "Home", action = "LogOn" } // 参数默认值
            );

            routes.MapRoute(
                "CategoryById", // 路由名称
                "{forumId}/{id}/Category.html", // 带有参数的 URL
                new { controller = "Category", action = "List", id = UrlParameter.Optional }, // 参数默认值
                new { forumId = guidRegx, id = guidRegx }
            );

            routes.MapRoute(
                "Category", // 路由名称
                "{forumId}/Category.html", // 带有参数的 URL
                new { controller = "Category", action = "List" }, // 参数默认值
                new { forumId = guidRegx }
            );

            routes.MapRoute(
                "Article", // 路由名称
                "Article/{id}.html", // 带有参数的 URL
                new { controller = "Article", action = "Get" }, // 参数默认值
                new { id = guidRegx }
            );

            routes.MapRoute(
                "Index", // 路由名称
                "Index.html", // 带有参数的 URL
                new { controller = "Home", action = "Index" } // 参数默认值
            );

            //base.RegisterRoutes(routes);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            if (this.Server.GetLastError() == null)
            {
                return;
            }

            Exception ex = this.Server.GetLastError().GetBaseException();
            StringBuilder sb = new StringBuilder();

            sb.Append(ex.Message);
            sb.Append("\r\nSOURCE: " + ex.Source);
            if (Request.Form != null)
            {
                sb.Append("\r\nFORM: " + this.Request.Form.ToString());
            }
            if (Request.QueryString != null)
            {
                sb.Append("\r\nQUERYSTRING: " + this.Request.QueryString.ToString());
            }

            sb.Append("\r\n引发当前异常的原因: " + ex.TargetSite);
            sb.Append("\r\n堆栈跟踪: " + ex.StackTrace);
            logger.Error(sb.ToString());

            var key = System.Configuration.ConfigurationManager.AppSettings["IsDebug"];
            bool isDebug;
            if (!bool.TryParse(key, out isDebug) || !isDebug)
            {
                this.Server.ClearError();
            }
        }

        protected void Session_Start()
        {
            this.Session["isCN"] = this.Request.UserLanguages.Length < 1 
                || string.IsNullOrEmpty(this.Request.UserLanguages[0]) 
                || this.Request.UserLanguages[0].ToLower() == "zh-cn";
        }
    }

    //public class MvcApplication : System.Web.HttpApplication
    //{
    //    public static void RegisterRoutes(RouteCollection routes)
    //    {
    //        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

    //        routes.MapRoute(
    //            "Default", // 路由名称
    //            "{controller}/{action}/{id}", // 带有参数的 URL
    //            new { controller = "Home", action = "Index", id = UrlParameter.Optional } // 参数默认值
    //        );

    //    }

    //    protected void Application_Start()
    //    {
    //        AreaRegistration.RegisterAllAreas();

    //        RegisterRoutes(RouteTable.Routes);
    //    }
    //}
}