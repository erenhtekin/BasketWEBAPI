using BasketWEBAPI.Models;
using BasketWEBAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace BasketWEBAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            var xml = GlobalConfiguration.Configuration.Formatters.XmlFormatter;
            xml.UseXmlSerializer = true;
            var products = DbProvider.GetInstance().ProductRepo;
            products.Add(
                new Product
                {
                    ProductName = "Keyboard",
                    ProductPrice = 50,
                    StockQuantity = 40
                }
            );
            products.Add(
                new Product
                {
                    ProductName = "Screen",
                    ProductPrice = 100,
                    StockQuantity = 20
                }
            );
            products.Add(
               new Product
               {
                   ProductName = "Mouse",
                   ProductPrice = 5,
                   StockQuantity = 30
               }
           );
            products.Add(
              new Product
              {
                  ProductName = "Flash Disk",
                  ProductPrice = 15,
                  StockQuantity = 20
              }
          );
        }
    }
}
