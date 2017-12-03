using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BasketWEBAPI.Models;
using BasketWEBAPI.Repositories;
using System.Web.Script.Services;
using System.Web.Services;

namespace BasketWEBAPI.Controllers
{
    [RoutePrefix("api/basket")]
    public class BasketController : ApiController
    {
        bool flag;
        ProductRepository productRepo = DbProvider.GetInstance().ProductRepo;
        BasketItemRepository basketRepo = DbProvider.GetInstance().BasketItemRepo;

        //GET api/<controller>

        // GET api/<controller>/5 
        [HttpGet]
        public List<BasketItem> Get([FromUri] int Customerid)
        {

           var items = DbProvider.GetInstance().BasketItemRepo.GetItemsOfCustomer(Customerid);
            return items.ToList();




        }

        [HttpPost]        // POST api/<controller>
        public string Post([FromBody] BasketItem model)
        {

            if (model != null)
            {

                var product = productRepo.Get(model.ProductId);//getting the product stock
                var CurrentBasketItem = basketRepo.GetCurrentItem(model.ProductId, model.CustomerId);//controlling the basket if there is a same product in previous orders
                if (product == null)
                {
                    return "not valid product";
                }
                else
                {
                    int count = product.StockQuantity;
                    int basketproductcount = CurrentBasketItem == null ? 0 : CurrentBasketItem.Count;//current basket count
                    if (count >= (model.Count + basketproductcount))
                    {

                        if (CurrentBasketItem == null)
                        {
                            model.TotalPrice = model.Count * product.ProductPrice;
                            model.ProductName = product.ProductName;
                            flag = basketRepo.Add(model);
                            if (flag)
                                return "Succesful";
                            else
                                return "Adding Error";
                        }
                        else
                        {
                            //Updating current quantity if same product exists in basket and then update
                            CurrentBasketItem.Count += model.Count;
                            flag = basketRepo.Update(CurrentBasketItem);
                            if (flag)
                                return "Succesful";
                            else
                                return "Adding Error";
                        }
                    }
                    else
                    {
                        return "Order quantity can not bigger than Stock Quantity";
                    }


                }
            }
            else
            {
                return "Model Needed";
                    
            }

        }

        // PUT api/<controller>/5
        public string Put([FromUri]BasketItem model)
        {

            if (model != null)
            {
                var product = productRepo.Get(model.ProductId);//getting the product stock
                var CurrentBasketItem = basketRepo.GetCurrentItem(model.ProductId, model.CustomerId);//controlling the basket if there is a same product in previous orders
                if (CurrentBasketItem != null)
                {
                    //devam edilecek !!
                    if (product == null)
                    {
                        return "not valid product";
                    }
                    else
                    {
                        int count = product.StockQuantity;
                        int basketproductcount = CurrentBasketItem == null ? 0 : CurrentBasketItem.Count;
                        if (count >= (model.Count + basketproductcount))
                        {
                            CurrentBasketItem.Count += model.Count;//sum same id of products if the basket has already one
                            model.TotalPrice = CurrentBasketItem.Count * product.ProductPrice;
                            model.ProductName = CurrentBasketItem.ProductName;
                            flag = basketRepo.Update(model);
                            if (flag)
                                return "Succesful";
                            else
                                return "Updating Error";
                        }
                        else
                        {
                            return "Order quantity can not bigger than Stock Quantity";
                        }

                    }
                }
                else
                {
                    return "There is no product to update";
                }


            }
            else
            {
                return "Model Needed";
            }

        }

        // DELETE api/<controller>/5
        public string Delete(int id)
        {
            var basketRepo = DbProvider.GetInstance().BasketItemRepo;
            bool flag = basketRepo.Delete(id);
            if (flag)
                return "Basket Item has deleted";
            else
                return "Deleting error";

        }
    }
}