using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eshoper_CD.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult getCategory()
        {
            ViewBag.meta = "san-pham";
            var lstCategory = new CategoryModel().GetCategories();
            return PartialView(lstCategory);
        }

        public ActionResult getCategoryTab()
        {
            var lstCategory = new CategoryModel().GetCategories();
            return PartialView(lstCategory);
        }

        public ActionResult getFeature()
        {
            var lstFeature = new FeatureItemModel().getFeature();
            return PartialView(lstFeature);
        }
        public ActionResult getProductCategoryTab(int id)
        {
            var lstProduct = new ProductModel().GetCategoryTab(id);
            return PartialView(lstProduct);
        }

        public ActionResult getRecommend()
        {
            return PartialView();
        }

        public ActionResult getRecommendItem()
        {
            var lst = new RecommendModel().GetRecommendList();
            return PartialView(lst);
        }

        public ActionResult leftLayout()
        {
            return PartialView();
        }
    }
}