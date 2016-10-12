using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstWebApplication.Entities;

namespace FirstWebApplication.Services
{
    interface IEntityService<T> where T:IMongoEnitity
    {
        void Create(T entity);
        void Delete(string id);
        T GetById(string id);
        void Update(T entity);
    }
}
