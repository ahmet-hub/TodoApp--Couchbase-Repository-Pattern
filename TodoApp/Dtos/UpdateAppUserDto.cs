using System.Collections.Generic;

namespace TodoApp.Dtos
{
    public class UpdateAppUserDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public List<TodoDto> TodoList = new();
    }
}
