using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;

namespace Eshoper_CD.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        [Route("san-pham")]
        public ActionResult Index(int? page)
        {
            var lstProduct = new ProductModel().GetProductList();
            return View(lstProduct.ToPagedList(page ?? 1,12));
        }
        public ActionResult GetDetail(int id)
        {
            var product = new ProductModel().GetProductDetail(id);
            return View(product);
        }
        public ActionResult GetCategoryByMeta (string meta)
        {
            var category = new CategoryModel().GetCategoryByMeta(meta);
            return View(category);
        }
        public ActionResult GetProductsByCategory(int id, int? page)
        {
            var products = new ProductModel().GetProductsByCategory(id);
            return PartialView(products.ToPagedList(page?? 1,6));
        }
    }
}