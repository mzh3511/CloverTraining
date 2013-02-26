using System.Web.Mvc;
using System.Web.Security;
using Clover.Service;
using Clover.Web.Models;

namespace Clover.Web.Controllers
{
    [Authorize]
    //[InitializeSimpleMembership]
    public class AccountController : Controller
    {
        public IUserInfoManager UserInfoManager { get; set; }

        //
        // GET: /Account/Login

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid && UserInfoManager.Login(model.UserName, model.Password))
            {
                FormsAuthentication.RedirectFromLoginPage(model.UserName, false);
                return RedirectToLocal(returnUrl);
            }

            // 如果我们进行到这一步时某个地方出错，则重新显示表单
            ModelState.AddModelError("", "提供的用户名或密码不正确。");
            return View(model);
        }

        //
        // POST: /Account/LogOff

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            //WebSecurity.Logout();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }


        #region 帮助程序
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Manage");
            }
        }
        #endregion
    }
}
