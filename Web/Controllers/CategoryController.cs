using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Clover.Service;
using Clover.Domain;

namespace Clover.Web.Controllers
{
    public class CategoryController : Controller
    {
        public ICategoryManager CategoryManager { get; set; }

        //public IForumManager ForumManager { get; set; }

        public IArticleManager ArticleManager { get; set; }
        //
        // GET: /Category/

        //[Authorize]
        //public ActionResult Index()
        //{
        //    return View();
        //}
        public ActionResult PartialRoot()
        {
            return PartialView(CategoryManager.GetSysCategory());
        }
    }
}
