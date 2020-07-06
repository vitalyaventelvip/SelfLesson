using SelfLesson.Server.API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SelfLesson.Server.API.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public Product Create(string name)
        {
            return productRepository.Create(name);
        }

        public Product Get(int id)
        {
            return productRepository.Read(id);
        }

        public List<Product> List()
        {
            return productRepository.List();
        }
    }
}
