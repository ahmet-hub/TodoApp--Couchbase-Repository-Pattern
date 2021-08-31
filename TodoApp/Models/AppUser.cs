using System;
using System.Collections.Generic;
using TodoApp.Dal;

namespace TodoApp.Models
{
    public class AppUser : DomainAggregate
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Todo> TodoList { get; set; }
    }
}
