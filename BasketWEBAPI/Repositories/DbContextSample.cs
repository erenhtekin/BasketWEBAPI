using BasketWEBAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasketWEBAPI.Repositories
{
    public class DbContextSample
    {
        public static List<Customer> Customers = new List<Customer>();
        public static List<Product> Products = new List<Product>();
        public static List<BasketItem> BasketItems = new List<BasketItem>();

    }
}