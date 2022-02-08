using MediatR;

namespace TodoApp.CQRS.Commands
{
    public class DeleteTodoItemCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
