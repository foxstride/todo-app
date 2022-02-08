using MediatR;
using TodoApp.ViewModels;

namespace TodoApp.CQRS.Commands
{
    public class UpdateTodoItem : IRequest<TodoViewModel>
    {
    }
}
