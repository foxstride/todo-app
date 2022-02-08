using MediatR;
using TodoApp.ViewModels;

namespace TodoApp.CQRS.Queries
{
    // Doesn't inherit from BaseTodoQuery because we don't really need a predicate when getting a single item
    public class SingleTodoQuery : IRequest<TodoViewModel>
    {
        public Guid Id { get; set; }
    }
}
