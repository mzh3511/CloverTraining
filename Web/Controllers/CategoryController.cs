using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            IList<Category> sysCateGoryList = CategoryManager.GetSysCategory();
            //StringBuilder sb = new StringBuilder();
            //sb.Append("<ul>");
            //foreach (Category category in sysCateGoryList)
            //{
            //    sb.Append(GetMenuHtml(category));
            //}
            //sb.Append("</ul>");
            return PartialView(sysCateGoryList);
        }
        /// <summary>
        /// 栏目路径
        /// </summary>
        /// <param name="id">当前栏目Id</param>
        /// <returns></returns>
        public ActionResult PartialPath(int id)
        {
            //List<Category> path = new List<Category>();
            //var category = CategoryManager.Get(id);
            //while (category != null)
            //{
            //    path.Insert(0, category);
            //    category = CategoryManager.Get(category.ParentId);
            //}
            return PartialView();
        }

        //public ActionResult PartialMenu(int parentCategoryId)
        //{
        //    return PartialView();
        //}
        private string GetMenuHtml(Category category)
        {
            StringBuilder sb = new StringBuilder();
            if (category == null || string.IsNullOrEmpty(category.MenuText))
                return sb.ToString();
            //string linkStr =
            //    string.Format(
            //        "@Html.ActionLink(item.MenuText, \"Article\", \"Home\", new {{ categoryId ={0} }}, null)",
            //        category.ID);
            string linkStr = string.Format("<a href=\"/Home/Article?categoryId={0}\">{1}</a>", category.ID, category.MenuText);
            sb.AppendFormat(@"<li>{0}", linkStr);
            if (category.SubCategories != null && category.SubCategories.Count > 0)
            {
                sb.Append("<ul>");
                foreach (Category subCategory in category.SubCategories)
                {
                    sb.Append(GetMenuHtml(subCategory));
                }
                sb.Append("</ul>");
            }
            sb.AppendFormat(@"</li>");
            return sb.ToString();
        }
    }
}
