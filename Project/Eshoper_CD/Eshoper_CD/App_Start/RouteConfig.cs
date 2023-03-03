using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Eshoper_CD
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.IgnoreRoute("{*botdetect}",
            new { botdetect = @"(.*)BotDetectCaptcha\.ashx" });

            routes.MapRoute(
                name: "Product",
                url: "san-pham/",
                defaults: new { controller = "Products", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Eshoper_CD.Controllers" }
            );
            routes.MapRoute(
                name: "Profile",
                url: "thong-tin-nguoi-dung/",
                defaults: new { controller = "Users", action = "Profiles", id = UrlParameter.Optional },
                namespaces: new[] { "Eshoper_CD.Controllers" }
            );
            routes.MapRoute(
                name: "Cart",
                url: "gio-hang/",
                defaults: new { controller = "Cart", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Eshoper_CD.Controllers" }
            );
            routes.MapRoute(
                name: "Checkout",
                url: "thanh-toan/",
                defaults: new { controller = "Checkout", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Eshoper_CD.Controllers" }
            );
            routes.MapRoute(
                name: "Product_By_Category",
                url: "san-pham/{meta}",
                defaults: new { controller = "Products", action = "GetCategoryByMeta", meta = UrlParameter.Optional },
                namespaces: new[] { "Eshoper_CD.Controllers" }
            );
            routes.MapRoute(
                name: "Product_Detail",
                url: "san-pham/chi-tiet/{id}",
                defaults: new { controller = "Products", action = "GetDetail", id = UrlParameter.Optional },
                namespaces: new[] { "Eshoper_CD.Controllers" }
            );
            routes.MapRoute(
                name: "HomePage",
                url: "trang-chu/",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Eshoper_CD.Controllers" }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Eshoper_CD.Controllers" }
            );
        }
    }
}
