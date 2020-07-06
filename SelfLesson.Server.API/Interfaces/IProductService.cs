using System.Collections.Generic;

namespace SelfLesson.Server.API.Interfaces
{
    public interface IProductService
    {
        Product Create(string name);
        Product Get(int id);
        List<Product> List();
    }
}