using MediatR;

namespace TodoApp.CQRS.Commands
{
    public class DeleteTodoItem : IRequest<bool>
    {
    }
}
