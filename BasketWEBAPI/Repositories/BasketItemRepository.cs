using BasketWEBAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasketWEBAPI.Repositories
{
    public class BasketItemRepository : IRepository<BasketItem>
    {
        List<BasketItem> items;

        public BasketItemRepository(List<BasketItem> items)
        {
            this.items = items;
        }


        public IEnumerable<BasketItem> All()
        {
            return items.AsEnumerable();
        }

        public BasketItem Get(int id)
        {
            return items.FirstOrDefault(x => x.Id == id);
        }

 

        public bool Add(BasketItem modelToAdd)
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


        public bool Update(BasketItem modelToUpdate)
        {
            try
            {
                var itemToUpdate = items.FirstOrDefault(x => x.Id == modelToUpdate.Id);

                if (itemToUpdate != null)
                {
                    // TODO call to db.

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


        public BasketItem GetCurrentItem(int productid, int customerid)
        {
            return items.FirstOrDefault(x => x.ProductId == productid && x.CustomerId == customerid);
        }



        public List<BasketItem> GetItemsOfCustomer(int customerId)
        {
            return items.Where(x => x.CustomerId == customerId).ToList();
        }



    }
}