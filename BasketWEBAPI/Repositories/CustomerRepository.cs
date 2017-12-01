using BasketWEBAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasketWEBAPI.Repositories
{
    public class CustomerRepository : IRepository<Customer>
    {
        List<Customer> items;

        public CustomerRepository(List<Customer> items)
        {
            this.items = items;
        }


        public IEnumerable<Customer> All()
        {
            return items.AsEnumerable();
        }

        public Customer Get(int id)
        {
            return items.FirstOrDefault(x => x.Id == id);
        }

        public bool Add(Customer modelToAdd)
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


        public bool Update(Customer modelToUpdate)
        {
            try
            {
                var itemToUpdate = items.FirstOrDefault(x => x.Id == modelToUpdate.Id);

                if(itemToUpdate != null)
                {
                    itemToUpdate.CustomerName = modelToUpdate.CustomerName;
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