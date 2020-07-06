using SelfLesson.Server.API.Core;
using SelfLesson.Server.API.Interfaces;
using SelfLesson.Server.API.Models;
using System.Collections.Generic;

namespace SelfLesson.Server.API.Services
{
    public class ProductWithCacheService : ProductService, IProductService
    {
        private readonly ICache cache;

        public ProductWithCacheService(ICache cache, IProductRepository productRepository)
            :base(productRepository)
        {
            this.cache = cache;
        }

        public new Product Get(int id)
        {
            return cache.GetOrUpdate(id.ToString(), () => base.Get(id));
        }

        public new List<Product> List()
        {
            return cache.GetOrUpdate("list", () => base.List());
        }
    }
}
