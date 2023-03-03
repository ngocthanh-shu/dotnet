using Eshoper_CD.Common;
using Eshoper_CD.Models;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProfileModel = Models.Models.ProfileModel;

namespace Eshoper_CD.Controllers
{
    public class CheckoutController : Controller
    {
        // GET: Checkout
        public ActionResult Index()
        {
            if (Session[CommonConstants.USER_SESSION] == null || Session[CommonConstants.USER_SESSION].ToString() == "")
            {
                return RedirectToAction("Login", "Users");
            }
            var user = (UserLogin)Session[CommonConstants.USER_SESSION];
            var username = user.username.ToString();
            var profile = new ProfileModel().GetProfileDetail(username);
            var rs = new CheckoutModel()
            {
                email = profile.email,
                fname = profile.fname,
                lname = profile.lname,
                address = profile.Address,
                zip = profile.postalcode,
                mobile = profile.phonenumber
            };
            return View(rs);
        }

        [HttpPost]
        public ActionResult Index(CheckoutModel model)
        {
            var user = (UserLogin)Session[CommonConstants.USER_SESSION];
            var username = user.username.ToString();
            var validation = new AccountModel().GetAccountDetail(username);
            if(model.password == validation.password)
            {
                var cartId = new CartModel().GetCartId(username);
                var closing = new CartModel().OrderClosing(cartId);
                if (closing)
                {
                    if(model.message == null)
                    {
                        model.message = " ";
                    }
                    var order = new OrderModel().AddOrder(cartId, model.lname + model.fname, model.address, model.mobile, model.message);
                    if (order)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Order not success");
                        return View(model);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Password is wrong!");
                return View(model);
            }
            return View(model);
        }

        public ActionResult Review()
        {
            var user = (UserLogin)Session[CommonConstants.USER_SESSION];
            var username = user.username.ToString();
            var cartId = new CartModel().GetCartId(username);
            List<ProductCartModel> models = new List<ProductCartModel>();
            var lstProducts = new CartDetailModel().GetProductList(cartId);
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

        public ActionResult Total()
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
    }
}