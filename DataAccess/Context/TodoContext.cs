using Microsoft.EntityFrameworkCore;
using TodoApp.DataAccess.Models;

namespace TodoApp.DataAccess.Context
{
    public class TodoContext : DbContext
    {
        public TodoContext()
        {
            TodoItems = Set<TodoItem>();
        }

        public TodoContext(DbContextOptions options) : base(options)
        {
            TodoItems = Set<TodoItem>();
        }

        public DbSet<TodoItem> TodoItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var timestamp = new DateTime(2022, 02, 07, 4, 30, 00);
            var todoItems = new List<TodoItem>
            {
                new TodoItem()
                {
                    Id = Guid.NewGuid(),
                    Title = "First Todo Item",
                    Description = "The First Description",
                    Finished = true,
                },

                new TodoItem()
                {
                    Id = Guid.NewGuid(),
                    Title = "Second Todo Item",
                    Description = "The Second Description",
                    Finished = false,
                },

                new TodoItem()
                {
                    Id = Guid.NewGuid(),
                    Title = "Code Interview",
                    Description = "Make a Todo app for Tonic",
                    Finished = false,
                    Created = timestamp,
                    Updated = timestamp
                }
            };

            builder.Entity<TodoItem>().HasData(todoItems);

            base.OnModelCreating(builder);
        }
    }
}
