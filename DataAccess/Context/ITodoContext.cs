using Microsoft.EntityFrameworkCore;
using TodoApp.DataAccess.Models;

namespace TodoApp.DataAccess.Context
{
    public interface ITodoContext
    {
        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
