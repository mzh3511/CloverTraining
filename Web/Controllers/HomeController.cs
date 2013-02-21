﻿using System;
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
            if(sysCategoryList==null||sysCategoryList.Count==0)
            {
                sysCategoryList = new List<Category>();
                sysCategoryList.Add(new Category() { IsSystem = true, MenuPriority = 0, MenuText = "会社案内" });
                sysCategoryList.Add(new Category() { IsSystem = true, MenuPriority = 0, MenuText = "レッスンのご案内" });
                sysCategoryList.Add(new Category() { IsSystem = true, MenuPriority = 0, MenuText = "教材" });
                sysCategoryList.Add(new Category() { IsSystem = true, MenuPriority = 0, MenuText = "学生様の声" });
                sysCategoryList.Add(new Category() { IsSystem = true, MenuPriority = 0, MenuText = "よくあるご質問" });
                sysCategoryList.Add(new Category() { IsSystem = true, MenuPriority = 0, MenuText = "連絡方法" });
                foreach (Category category in sysCategoryList)
                {
                    CategoryManager.Save(category);
                }
            }

            ViewData.Add("SysCategory1",sysCategoryList[1]);
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
        public ActionResult Article(int id = -1)
        {
            return View();
        }
    }
}
