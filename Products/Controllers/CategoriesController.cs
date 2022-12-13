using System;
using Microsoft.AspNetCore.Mvc;
using Products.Models;
using Products.Repository;

namespace Products.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController
	{

        CategoryRepository repository;

        public CategoriesController(ILogger<WeatherForecastController> logger)
        {
            repository = new CategoryRepository();
        }

        [HttpGet(Name = "GetAllCategory")]
        public ActionResult<List<Category>> Get()
        {
            return repository.getAll();
        }
        [HttpGet("{id:int}")]
        public ActionResult<Category> Get(int id)
        {
            return repository.GetCategpryById(id);
        }
        [HttpPost()]
        public IResult insert(Category category)
        {
            bool isSuccess = repository.Insert(category);
            return isSuccess ? Results.Ok() : Results.BadRequest();
        }

        [HttpPut()]
        public IResult update(Category category)
        {
            bool isSuccess = repository.Update(category);
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


