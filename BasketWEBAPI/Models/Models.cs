using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasketWEBAPI.Models
{

    public class Product : IModel
    {
        public int Id { get; set; }

        public string ProductName { get; set; }
        public double ProductPrice { get; set; }

        public int StockQuantity { get; set; }
    }
    public class Customer : IModel
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
    }
    public class BasketItem : IModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }

        public int ProductId { get; set; }
        public int Count { get; set; }
        public double TotalPrice { get; set; }
        public bool isConfirmed { get; set; }
        public DateTime ConfirmedDay { get; set; }
    }


}