using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SelfLesson.Server.API.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SelfLesson.Server.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        /// <summary>
        /// Получить список товаров
        /// </summary>
        [HttpGet]
        public List<Product> Get()
        {
            return productService.List();
        }
        
        /// <summary>
        /// Получить товар
        /// </summary>
        /// <param name="id">Идентификатор товара</param>
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            var product = productService.Get(id);

            if (product == null)
            {
                throw new NullReferenceException();
            }
            
            return product;
        }

        /// <summary>
        /// Добавить товар
        /// </summary>
        /// <param name="name">Наименвоание товара</param>
        [HttpPost]
        [Route("add")]
        public Product Post(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException();
            }

            return productService.Create(name);
        }
    }
}
