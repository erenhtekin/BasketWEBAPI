using BasketWEBAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasketWEBAPI.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        List<Product> items;

        public ProductRepository(List<Product> items)
        {
            this.items = items;
        }


        public IEnumerable<Product> All()
        {
            return items.AsEnumerable();
        }

        public Product Get(int id)
        {
            return items.FirstOrDefault(x => x.Id == id);
        }

        public bool Add(Product modelToAdd)
        {
            try
            {
                int maxId = items.Any() ? items.Max(x => x.Id) : 0;

                modelToAdd.Id = maxId + 1;
                items.Add(modelToAdd);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public bool Update(Product modelToUpdate)
        {
            try
            {
                var itemToUpdate = items.FirstOrDefault(x => x.Id == modelToUpdate.Id);

                if(itemToUpdate != null)
                {
                    itemToUpdate.ProductName = modelToUpdate.ProductName;
                    itemToUpdate.ProductPrice = modelToUpdate.ProductPrice;
                    itemToUpdate.StockQuantity = modelToUpdate.StockQuantity;
                    return true;
                }

                return false;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var itemToDelete = items.FirstOrDefault(x => x.Id == id);

                if (itemToDelete != null)
                {
                    items.Remove(itemToDelete);
                    return true;
                }

                return false;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        

       
    }
}