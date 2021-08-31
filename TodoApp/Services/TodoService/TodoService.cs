using AutoMapper;
using System;
using System.Threading.Tasks;
using TodoApp.Dal;
using TodoApp.Dtos;
using TodoApp.Models;

namespace TodoApp.Services.TodoService
{
    public class TodoService : ITodoService
    {
        private readonly IRepository<Todo> _repository;
        private readonly IMapper _mapper;

        public TodoService(IRepository<Todo> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<Response<Todo>> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<TodoDto>> Get(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<Todo>> Insert(TodoDto todoDto)
        {
           return await _repository.CreateAsync(_mapper.Map<Todo>(todoDto));
        }

        public Task<Response<Todo>> Update(TodoDto updateUserDto)
        {
            throw new NotImplementedException();
        }
    }
}
