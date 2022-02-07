using TodoApp.DataAccess.Models;

namespace TodoApp.ViewModels
{
    public class TodoViewModel
    {
        public IList<TodoItem> TodoItems { get; set; } = new List<TodoItem>();
    }
}
