using System.Threading.Tasks;
using TodoApp.Dtos;
using TodoApp.Models;

namespace TodoApp.Services.UserService
{
    public interface IUserService
    {
        Task<Response<AppUserDto>> Get(string id);
        Task<Response<AppUser>> Insert(AppUserDto userDto);
        Task<Response<AppUser>> Update(UpdateAppUserDto updateUserDto);
        Task<Response<AppUser>> Delete(string id);
    }
}
