using AutoMapper;
using System.Threading.Tasks;
using TodoApp.Dal;
using TodoApp.Dtos;
using TodoApp.Models;

namespace TodoApp.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IRepository<AppUser> _repository;
        private readonly IMapper _mapper;
        public UserService(IRepository<AppUser> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<AppUserDto>> Get(string id)
        {
            var result = await _repository.GetAsync(id);
            if (result.IsSuccess)
                return Response.Ok<AppUserDto>("Success", _mapper.Map<AppUserDto>(result.Data));

            return Response.Fail<AppUserDto>(result.Message);
        }
        public async Task<Response<AppUser>> Delete(string id)
        {
            return await _repository.DeleteAsync(id);
        }
        public async Task<Response<AppUser>> Insert(AppUserDto userDto)
        {
            return await _repository.CreateAsync(_mapper.Map<AppUser>(userDto));
        }

        public async Task<Response<AppUser>> Update(UpdateAppUserDto userDto)
        {
            return await _repository.UpdateAsync(_mapper.Map<AppUser>(userDto));
        }
    }
}
