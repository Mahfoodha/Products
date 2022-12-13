using System;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using Products.Repository;
using Products.Models;

namespace Products.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        ProductRepository repository;

        public ProductController(ILogger<WeatherForecastController> logger)
        {
            repository = new ProductRepository();
        }

        [HttpGet(Name = "GetAllProducts")]
        public ActionResult<List<Product>> Get()
        {
            return repository.getAll();
        }
        [HttpGet("{id:int}")]
        public ActionResult<Product> Get(int id)
        {
            return repository.GetProductById(id);
        }
        [HttpPost()]
        public IResult insert(Product product)
        {
            bool isSuccess = repository.Insert(product);
            return isSuccess  ? Results.Ok() : Results.BadRequest();
        }

        [HttpPut()]
        public IResult update(Product product)
        {
            bool isSuccess = repository.Update(product);
            return isSuccess ? Results.Ok() : Results.BadRequest();
        }

        [HttpDelete("{id:int}")]
        public IResult Delete(int id)
        {
            bool isSuccess = repository.Delete(id);
            return isSuccess ? Results.Ok() : Results.BadRequest();
        }
    }
}

