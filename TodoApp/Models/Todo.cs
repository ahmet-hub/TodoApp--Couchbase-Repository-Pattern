using System;
using TodoApp.Dal;

namespace TodoApp.Models
{
    public class Todo : DomainAggregate
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public DateTime Deadline { get; set; }
        public bool IsDone { get; set; }
        public string UserId{ get; set; }
    }
}
