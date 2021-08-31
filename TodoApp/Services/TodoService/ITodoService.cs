using System.Threading.Tasks;
using TodoApp.Dtos;
using TodoApp.Models;

namespace TodoApp.Services.TodoService
{
    public interface ITodoService

    {
        Task<Response<TodoDto>> Get(string id);
        Task<Response<Todo>> Insert(TodoDto todoDto);
        Task<Response<Todo>> Update(TodoDto updateUserDto);
        Task<Response<Todo>> Delete(string id);
    }
}
