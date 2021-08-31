using System.Collections.Generic;

namespace TodoApp.Dtos
{
    public class AppUserDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<TodoDto> TodoList { get; set; } 
}
}
