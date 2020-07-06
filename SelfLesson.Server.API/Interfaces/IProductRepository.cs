using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfLesson.Server.API.Interfaces
{
    public interface IProductRepository
    {
        Product Create(string name);
        void Delete(int id);
        Product Read(int id);
        List<Product> List();
        Product Update(string name);
    }
}
