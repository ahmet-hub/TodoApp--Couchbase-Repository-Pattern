using System;
using TodoApp.Models;

namespace TodoApp.Dtos
{
    public class TodoDto
    {
        public string Name { get; set; }
        public DateTime Deadline { get; set; }
        public bool IsDone { get; set; }
        public string UserId{ get; set; }
    }
}