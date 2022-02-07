using TodoApp.DataAccess.Models;

namespace TodoApp.DataAccess.Repositories
{
    public interface ITodoRepository
    {
        Task<List<TodoItem>> GetTodoItems();
        Task<TodoItem> GetTodoItem(Guid id);
        Task<List<TodoItem>> GetUnfinishedTodoItems();
        Task<List<TodoItem>> GetFinishedTodoItems();
    }
}