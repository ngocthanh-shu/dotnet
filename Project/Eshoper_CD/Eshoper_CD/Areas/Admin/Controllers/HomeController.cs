using Eshoper_CD.Models;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eshoper_CD.Areas.Admin.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            var lst = new OrderModel().GetOrderList();
            return View(lst);
        }

        public ActionResult OrderDetail(int id)
        {
            var order = new OrderModel().GetOrderDetail(id);
            return View(order);
        }

        public ActionResult Preview(int id)
        {
            List<ProductCartModel> models = new List<ProductCartModel>();
            var lstProducts = new CartDetailModel().GetProductList(id);
            foreach (var product in lstProducts)
            {
                var productDetail = new ProductModel().GetProductDetail(product.productid);
                var model = new ProductCartModel()
                {
                    cartId = product.cartid,
                    productId = product.productid,
                    productImg = productDetail.img,
                    productName = productDetail.name,
                    productPrice = product.singleprice,
                    cartQuanity = product.quantity,
                    total = product.total
                };
                models.Add(model);
            }
            return PartialView(models);
        }

        public ActionResult RejectOrder(int id)
        {
            var reject = new OrderModel().RejectOrder(id);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ApproveOrder(int id)
        {
            var approve = new OrderModel().ApproveOrder(id);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Total(int id)
        {
            var cart = new CartModel().GetCartById(id);
            var rs = new CartConfirmModel()
            {
                cartId = cart.id,
                totalProduct = cart.totalprice,
                ecoTax = cart.totalproduct,
                shippingCost = cart.totalproduct * 3,
            };
            rs.total = rs.totalProduct + rs.ecoTax + rs.shippingCost;
            return PartialView(rs);
            
        }
    }
}