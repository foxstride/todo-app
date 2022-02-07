using Microsoft.EntityFrameworkCore;
using TodoApp.DataAccess.Models;

namespace TodoApp.DataAccess.Context
{
    public class TodoContext : DbContext, ITodoContext
    {
        public TodoContext()
        {
            TodoItems = Set<TodoItem>();
        }

        public TodoContext(DbContextOptions options)
        {
            TodoItems = Set<TodoItem>();
        }

        public DbSet<TodoItem> TodoItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            if (!TodoItems.Any())
            {
                TodoItems.Add(new TodoItem() { 
                    Id = Guid.NewGuid(),
                    Title = "First Todo Item",
                    Description = "The First Description",
                    Finished = true,
                });

                TodoItems.Add(new TodoItem()
                {
                    Id = Guid.NewGuid(),
                    Title = "Second Todo Item",
                    Description = "The Second Description",
                    Finished = false,
                });

                var timestamp = new DateTime(2022, 02, 07, 4, 30, 00);
                TodoItems.Add(new TodoItem()
                {
                    Id = Guid.NewGuid(),
                    Title = "Code Interview",
                    Description = "Make a Todo app for Tonic",
                    Finished = false,
                    Created = timestamp,
                    Updated = timestamp
                });
            }

            base.OnModelCreating(builder);
        }
    }
}
