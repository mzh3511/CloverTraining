using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Clover.Domain;
using Clover.Service;
using System.Web.Security;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Drawing.Imaging;
using Clover.Web.Models;

namespace Clover.Web.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ICategoryManager CategoryManager { get; set; }
        public IArticleManager ArticleManager { get; set; }

        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Index()
        {
            IList<Category> sysCategoryList = CategoryManager.GetSysCategory();
            if (sysCategoryList == null || sysCategoryList.Count == 0)
            {
                sysCategoryList = new List<Category>();
                Category category1 = new Category() { IsSystem = true, MenuPriority = 0, MenuText = "会社案内" };
                sysCategoryList.Add(category1);
                category1.SubCategories.Add(new Category() { MenuPriority = 1, MenuText = "クローバーの理念", ParentCategory = category1 });
                category1.SubCategories.Add(new Category() { MenuPriority = 1, MenuText = "優しい点", ParentCategory = category1 });

                Category category2 = new Category() { IsSystem = true, MenuPriority = 0, MenuText = "レッスンのご案内" };
                sysCategoryList.Add(category2);


                sysCategoryList.Add(new Category() { IsSystem = true, MenuPriority = 0, MenuText = "教材" });
                sysCategoryList.Add(new Category() { IsSystem = true, MenuPriority = 0, MenuText = "学生様の声" });
                sysCategoryList.Add(new Category() { IsSystem = true, MenuPriority = 0, MenuText = "よくあるご質問" });
                sysCategoryList.Add(new Category() { IsSystem = true, MenuPriority = 0, MenuText = "連絡方法" });
                foreach (Category category in sysCategoryList)
                {
                    CategoryManager.Save(category);
                }
            }

            ViewData.Add("SysCategory1", sysCategoryList[1]);
            return View();
        }
        public ActionResult Idea()
        {
            return View();
        }
        public ActionResult Advantage()
        {
            return View();
        }
        public ActionResult Guide()
        {
            return View();
        }
        public ActionResult Course()
        {
            return View();
        }
        public ActionResult Faqs()
        {
            return View();
        }
        public ActionResult Article(int categoryId = -1)
        {
            Category category = CategoryManager.Get(categoryId);
            if (category == null || category.Article == null)
            {
                NoticeModel notice = new NoticeModel { Title = "没有找到内容", Details = "没有找到相关的内容，请浏览其它部分", DwellTime = 5, NavigationName = "网站主页", NavigationUrl = Url.Action("Index", "Home") };
                return RedirectToAction("Notice", "Prompt", notice);
            }
            return View(category.Article);
        }
    }
}
