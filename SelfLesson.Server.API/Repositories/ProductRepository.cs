using Microsoft.AspNetCore.Mvc;
using SelfLesson.Server.API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfLesson.Server.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private Dictionary<int, Product> Records = new Dictionary<int, Product>();
        private int Total => Records.Count;

        private int GetRandomCount()
        {
            Random random = new Random();
            return random.Next(1, 100);
        }

        private object obj = new object();

        public Product Create(string name)
        {
            Product product;

            lock (obj)
            {
                int id = Total + 1;

                product = new Product()
                {
                    Id = id,
                    Name = name,
                    Count = GetRandomCount()
                };

                Records.Add(id, product);
            }
            return product;
        }

        public void Delete(int id)
        {
            lock (obj)
            {
                Records.Remove(id);
            }
        }

        public List<Product> List()
        {
            lock (obj)
            {
                return Records.Values.ToList();
            }
        }

        public Product Read(int id)
        {
            lock (obj)
            {

                Records.TryGetValue(id, out var product);
                return product;
            }
        }

        public Product Update(string name)
        {
            throw new NotImplementedException();
        }
    }
}
