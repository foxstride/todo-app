using TodoApp.DataAccess.Models;

namespace TodoApp.DataAccess.Repositories
{
    public interface ITodoRepository
    {
        Task<List<TodoItem>> GetTodoItems();
        Task<List<TodoItem>> GetTodoItems(Func<TodoItem, bool> filter);
        Task<TodoItem> GetTodoItem(Guid id);
    }
}