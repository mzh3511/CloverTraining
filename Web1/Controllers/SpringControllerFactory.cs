using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using Spring.Context;
using Spring.Context.Support;

namespace Clover.Web.Controllers
{
    /// <summary>
    /// Spring.NET ControllerFacotry
    /// </summary>
    public class SpringControllerFactory : IControllerFactory
    {
        /// <summary>
        /// Default ControllerFactory
        /// </summary>
        private static DefaultControllerFactory defalutf = null;

        public IController CreateController(System.Web.Routing.RequestContext requestContext, string controllerName)
        {
            //get spring context
            WebApplicationContext ctx = ContextRegistry.GetContext() as WebApplicationContext;
            string controller = "Clover.Web.Controllers." + controllerName + "Controller";
            //查找是否配置该Controller
            if (ctx.ContainsObject(controller))
            {
                object controllerf = ctx.GetObject(controller);
                return (IController)controllerf;

            }
            else
            {
                if (defalutf == null)
                {
                    defalutf = new DefaultControllerFactory();
                }

                return defalutf.CreateController(requestContext, controllerName);

            }

        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            return SessionStateBehavior.Required;
        }

        public void ReleaseController(IController controller)
        {
            //get spring context
            IApplicationContext ctx = ContextRegistry.GetContext();
            if (!ctx.ContainsObject(controller.GetType().Name))
            {
                if (defalutf == null)
                {
                    defalutf = new DefaultControllerFactory();
                }

                defalutf.ReleaseController(controller);
            }
        }

    }
}