using Microsoft.EntityFrameworkCore;
using TodoApp.DataAccess.Context;
using TodoApp.DataAccess.Models;

namespace TodoApp.DataAccess.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly ILogger<TodoRepository> _logger;
        private readonly TodoContext _context;

        public TodoRepository(TodoContext context, ILogger<TodoRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<TodoItem>> GetTodoItems()
        {
            return await _context.TodoItems.ToListAsync();
        }

        public async Task<List<TodoItem>> GetTodoItems(Func<TodoItem, bool> filter)
        {
            return await _context.TodoItems.Where(x => filter(x)).ToListAsync();
        }

        public async Task<TodoItem> GetTodoItem(Guid id)
        {
            return await _context.TodoItems.FirstOrDefaultAsync(x => x.Id == id) ?? new TodoItem();
        }

        public async Task<TodoItem> AddTodoItem(TodoItem item)
        {
            var result = await _context.TodoItems.AddAsync(item);
            var updated = await _context.SaveChangesAsync();
            return updated > 0 ? result.Entity : new TodoItem();
        }

        public async Task<TodoItem> UpdateTodoItem(TodoItem item)
        {
            var result = await _context.TodoItems.FirstOrDefaultAsync(x => x.Id == item.Id);
            if (result == null) 
                return new TodoItem();
            
            result.Updated = DateTime.Now;
            result.Title = item.Title;
            result.Description = item.Description;
            result.Finished = item.Finished;
            var updated = await _context.SaveChangesAsync();

            return updated > 0 ? result : new TodoItem();
        }

        public async Task<bool> DeleteTodoItem(Guid id)
        {
            var result = _context.TodoItems.Remove(new TodoItem() { Id = id });
            try
            {
                var updated = await _context.SaveChangesAsync();
                return updated > 0;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return false;
            }
        }
    }
}
