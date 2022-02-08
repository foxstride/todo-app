using MediatR;
using TodoApp.DataAccess.Models;
using TodoApp.ViewModels;

namespace TodoApp.CQRS.Queries
{
    public class BaseTodoQuery : IRequest<TodoViewModel>
    {
        public Func<TodoItem, bool> Predicate { get; set; } = (todoItem) => true;
    }
}
