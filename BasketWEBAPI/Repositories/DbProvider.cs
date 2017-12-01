using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasketWEBAPI.Repositories
{
    public class DbProvider
    {

        private static DbProvider _instance = new DbProvider();
        

        public static void RefreshDb()
        {
            _instance = null;
        }

        public static DbProvider GetInstance()
        {
            return _instance;
        }

        private CustomerRepository _customerRepository;

        public CustomerRepository CustomerRepo
        {
            get { return _customerRepository ?? (_customerRepository = new CustomerRepository(DbContextSample.Customers)); }
        }

        private ProductRepository _productRepository;

        public ProductRepository ProductRepo
        {
            get { return _productRepository ?? (_productRepository = new ProductRepository(DbContextSample.Products)); }
        }

        private BasketItemRepository _basketItemRepository;

        public BasketItemRepository BasketItemRepo
        {
            get { return _basketItemRepository ?? (_basketItemRepository = new BasketItemRepository(DbContextSample.BasketItems)); }
        }





    }
}