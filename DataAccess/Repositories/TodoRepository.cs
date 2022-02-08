using Microsoft.EntityFrameworkCore;
using TodoApp.DataAccess.Context;
using TodoApp.DataAccess.Models;

namespace TodoApp.DataAccess.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly ILogger<TodoRepository> _logger;
        private readonly ITodoContext _context;

        public TodoRepository(ITodoContext context, ILogger<TodoRepository> logger)
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
            return _context.TodoItems.Where(filter).ToList();
        }

        public async Task<TodoItem> GetTodoItem(Guid id)
        {
            return await _context.TodoItems.FirstOrDefaultAsync(x => x.Id == id) ?? new TodoItem();
        }
    }
}
