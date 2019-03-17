using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace shopxanh
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{*botdetect}",
      new { botdetect = @"(.*)BotDetectCaptcha\.ashx" });

            routes.MapRoute(
                name: "Detail product centagory",
                url: "chi-tiet/{metatile}-{id}",
                defaults: new { controller = "Product", action = "Index", id = UrlParameter.Optional },
                 namespaces: new[] { "OnlineShop.Controllers" }

            );
            routes.MapRoute(
                name: "Contact",
                url: "lien-he",
                defaults: new { controller = "Contact", action = "Index", id = UrlParameter.Optional },
                 namespaces: new[] { "OnlineShop.Controllers" }

            );
            routes.MapRoute(
                name: "Login",
                url: "dang-nhap",
                defaults: new { controller = "User", action = "Login", id = UrlParameter.Optional },
                 namespaces: new[] { "OnlineShop.Controllers" }

            );
            routes.MapRoute(
               name: "Search",
               url: "tim-kiem",
               defaults: new { controller = "Product", action = "Search", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineShop.Controllers" }

           );
            routes.MapRoute(
                name: "Content",
                url: "tin-tuc",
                defaults: new { controller = "Content", action = "Index", id = UrlParameter.Optional },
                 namespaces: new[] { "OnlineShop.Controllers" }
            );
            routes.MapRoute(
                name: "About",
                url: "gioi-thieu",
                defaults: new { controller = "About", action = "Index", id = UrlParameter.Optional },
                 namespaces: new[] { "OnlineShop.Controllers" }
            );
            routes.MapRoute(
                name: "Register",
                url: "dang-ki",
                defaults: new { controller = "User", action = "Register", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineShop.Controllers" }
            );
            routes.MapRoute(
                name: "detail cetagory",
                url: "san-pham/{metatile}-{CateId}",
                defaults: new { controller = "Product", action = "centagory", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineShop.Controllers" }
            );
            routes.MapRoute(
                name: "Detail Content",
                url: "tin-tuc/{Meta_title}-{id}",
                defaults: new { controller = "Content", action = "detailcontent", id = UrlParameter.Optional },
               namespaces: new[] { "OnlineShop.Controllers" }
            );
            routes.MapRoute(
               name: "Cart",
               url: "gio-hang",
               defaults: new { controller = "Cart", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "OnlineShop.Controllers" }
           );
            routes.MapRoute(
                name: "Add Cart",
                url: "them-gio-hang",
                defaults: new { controller = "Cart", action = "AddItem", id = UrlParameter.Optional },
                 namespaces: new[] { "OnlineShop.Controllers" }
            );
            routes.MapRoute(
                name: "Payment",
                url: "thanh-toan",
                defaults: new { controller = "Cart", action = "Payment", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineShop.Controllers" }
            );
            routes.MapRoute(
               name: "Payment Scuccess",
               url: "hoan-thanh",
               defaults: new { controller = "Cart", action = "Success", id = UrlParameter.Optional },
               namespaces: new[] { "OnlineShop.Controllers" }
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "OnlineShop.Controllers" }
            );
        }
    }
}
