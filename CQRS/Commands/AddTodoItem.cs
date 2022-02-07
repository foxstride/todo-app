using MediatR;
using TodoApp.ViewModels;

namespace TodoApp.CQRS.Commands
{
    public class AddTodoItem : IRequest<TodoViewModel>
    {
    }
}
