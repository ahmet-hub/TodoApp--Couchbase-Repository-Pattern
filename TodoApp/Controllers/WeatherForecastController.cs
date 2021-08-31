using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TodoApp.Dal;
using TodoApp.Models;

namespace TodoApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly IRepository<AppUser> _repository;

        public WeatherForecastController(IRepository<AppUser> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _repository.CreateAsync(new AppUser { Id = Guid.NewGuid().ToString(), Name = "ahmet", Email = "gmail.com", Password = "1234" });
            return Ok(result);

            //var result = await _repository.GetAllAsync();
            //return Ok(result);
        }
    }
}
