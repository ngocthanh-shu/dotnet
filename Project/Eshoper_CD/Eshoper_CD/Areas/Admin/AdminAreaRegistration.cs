using System.Web.Mvc;

namespace Eshoper_CD.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_login",
                "Admin/dang-nhap",
                new { action = "Index", Controller = "Login", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "Admin_Home",
                "Admin/trang-chu",
                new { action = "Index", Controller = "Home", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "Admin_OrderDetail",
                "Admin/chi-tiet-don-hang/{id}",
                new { action = "OrderDetail", Controller = "Home", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "Admin_Product",
                "Admin/san-pham/",
                new { action = "Index", Controller = "Products", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "Admin_Product_CreateProduct",
                "Admin/san-pham/them-san-pham/",
                new { action = "CreateProduct", Controller = "Products", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "Admin_Product_ProductDetail",
                "Admin/san-pham/chi-tiet-san-pham/{id}",
                new { action = "ProductDetail", Controller = "Products", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "Admin_Account",
                "Admin/tai-khoan/",
                new { action = "Index", Controller = "Accounts", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "Admin_Account_AccountDetail",
                "Admin/tai-khoan/chi-tiet-tai-khoan/{id}",
                new { action = "AccountDetail", Controller = "Accounts", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "Admin_Account_CreateAccount",
                "Admin/tai-khoan/them-tai-khoan",
                new { action = "CreateAccount", Controller = "Accounts", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "Admin_Account_ComplteProfile",
                "Admin/tai-khoan/them-tai-khoan/hoan-thien-thong-tin/{id}",
                new { action = "CompleteProfile", Controller = "Accounts", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", Controller = "Home" , id = UrlParameter.Optional }
            );
        }
    }
}