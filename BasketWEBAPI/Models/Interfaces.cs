using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasketWEBAPI.Models
{
    public interface IRepository<T> where T : class, IModel
    {

        IEnumerable<T> All();

        T Get(int id);

        bool Add(T modelToAdd);

        bool Update(T modelToUpdate);

        bool Delete(int id);
    }

    public interface IModel
    {
        int Id { get; set; }
    }
}