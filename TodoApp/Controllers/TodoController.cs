using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TodoApp.Dtos;
using TodoApp.Services.TodoService;

namespace TodoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(TodoDto todoDto)
        {
            var result = await _todoService.Insert(todoDto);

            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
