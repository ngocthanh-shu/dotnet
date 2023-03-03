using Eshoper_CD.Areas.Admin.Models;
using Models.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eshoper_CD.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Admin/Products
        public ActionResult Index()
        {
            var lstProducts = new ProductModel().GetProductList();
            return View(lstProducts);
        }
        public ActionResult CreateProduct()
        {
            var product = new CreateProduct
            {
                datebegin = DateTime.Now,
                categories = new CategoryModel().GetCategories()
            };
            return View(product);
        }
        [HttpPost]
        public ActionResult CreateProduct(CreateProduct product)
        {
            int categoryId = product.categoryId;
            product.categories = new CategoryModel().GetCategories();
            if (product.image != null && product.image.ContentLength>0)
            {
                string imgName = Path.GetFileNameWithoutExtension(product.image.FileName);
                string ext = Path.GetExtension(product.image.FileName);
                imgName = imgName + DateTime.Now.ToString("yymmssfff") + ext;
                product.img = imgName;
                string imgPath = Path.Combine(Server.MapPath("~/Assets/Client/images/products"),imgName);
                if (ModelState.IsValid)
                {
                    var result = new ProductModel().AddProduct(product.name, product.price, product.img, product.description, product.datebegin, product.quantity, product.categoryId);
                    if (result != null)
                    {
                        product.image.SaveAs(imgPath);
                        return RedirectToAction("Index");
                    }
                }
            }
            return View(product);
        }
        public ActionResult ProductDetail(int id)
        {
            var product = new ProductModel().GetProductDetail(id);
            var item = new CreateProduct
            {
                categories = new CategoryModel().GetCategories(),
                name = product.name,
                price = (float)product.price,
                img = product.img,
                description = product.description,
                datebegin = (DateTime)product.datebegin,
                quantity = (int) product.quantity,
                categoryId = (int) product.categoryid,
            };
            return View(item);
        }

        [HttpPost]
        public ActionResult ProductDetail(int id, CreateProduct product)
        {
            product.categories = new CategoryModel().GetCategories();
            if (ModelState.IsValid)
            {
                if(product.image != null)
                {
                    string imgPath = Path.Combine(Server.MapPath("~/Assets/Client/images/products"), product.img);
                    FileInfo file = new FileInfo(imgPath);
                    file.Delete();
                    product.image.SaveAs(imgPath);
                }
                var result = new ProductModel().UpdateProduct(id, product.name, product.price, product.description, product.quantity, product.categoryId);
                if (result != null)
                    return View(product);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(CreateProduct product)
        {
            if (ModelState.IsValid)
            {
                var result = new ProductModel().DeleteProduct(product.img);
                if(result == null)
                {
                    return View(product);
                }
            }
            return RedirectToAction("Index");
        }
    }
}