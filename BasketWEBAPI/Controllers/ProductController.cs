using BasketWEBAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BasketWEBAPI.Models
{
    [RoutePrefix("api/product")]
    public class ProductController : ApiController
    {
        ProductRepository productRepo = DbProvider.GetInstance().ProductRepo;

        [HttpGet]
        public List<Product> Get()
        {
            var items = productRepo.All();
            return items.ToList();
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}