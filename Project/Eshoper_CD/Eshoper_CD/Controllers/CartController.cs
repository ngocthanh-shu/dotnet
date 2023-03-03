using Eshoper_CD.Common;
using Eshoper_CD.Models;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eshoper_CD.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            if (Session[CommonConstants.USER_SESSION] == null || Session[CommonConstants.USER_SESSION].ToString() == "")
            {
                return RedirectToAction("Login", "Users");
            }
            var user = (UserLogin)Session[CommonConstants.USER_SESSION];
            var username = user.username.ToString();
            var cartId = new CartModel().GetCartId(username);
            List<ProductCartModel> models = new List<ProductCartModel>();
            var lstProducts = new CartDetailModel().GetProductList(cartId);
            foreach(var product in lstProducts)
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
            return View(models);
        }

        public ActionResult ConfirmCart()
        {
            var user = (UserLogin)Session[CommonConstants.USER_SESSION];
            var username = user.username.ToString();
            var cart = new CartModel().GetCart(username);
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

        public ActionResult AddToCart(int id)
        {
            if (Session[CommonConstants.USER_SESSION] == null || Session[CommonConstants.USER_SESSION].ToString() == "")
            {
                return RedirectToAction("Login", "Users");
            }
            var user = (UserLogin)Session[CommonConstants.USER_SESSION];
            var username = user.username.ToString();
            var rs = new CartModel().AddProductIntoCart(id, username);
            if (rs)
            {
                return RedirectToAction("GetDetail", "Products", new { id = id });
            }
            return RedirectToAction("Index", "Home");
            
        }

        public ActionResult AddQuantity(int cartId, int productId)
        {
            var add = new CartDetailModel().AddProductQuantity(productId, cartId);
            if (add)
            {
                return RedirectToAction("Index", "Cart");
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ReduceQuanity(int cartId, int productId)
        {
            var reduce = new CartDetailModel().ReduceProductQuantity(productId, cartId);
            if (reduce)
            {
                return RedirectToAction("Index", "Cart");
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult DropProduct(int cartId, int productId)
        {
            var delete = new CartDetailModel().DeleteProduct(productId, cartId);
            if (delete)
            {
                return RedirectToAction("Index", "Cart");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}