using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace BasketWEBAPI.Models
{

    public class Product : IModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("productName")]
        public string ProductName { get; set; }

        [JsonProperty("productPrice")]
        public double ProductPrice { get; set; }

        [JsonProperty("stockQuantity")]
        public int StockQuantity { get; set; }
    }
    public class Customer : IModel
    {

        public int Id { get; set; }
        public string CustomerName { get; set; }
    }
    public class BasketItem : IModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("customerId")]
        public int CustomerId { get; set; }

        [JsonProperty("productId")]
        public int ProductId { get; set; }

        [JsonProperty("productName")]
        public string ProductName { get; set; }

        [JsonProperty("count")]
        [Range(1, Int32.MaxValue)]
        public int Count { get; set; }

        [JsonProperty("totalPrice")]
        public double TotalPrice { get; set; }

        [JsonProperty("confirmedDay")]
        public DateTime ConfirmedDay { get; set; }
    }


}