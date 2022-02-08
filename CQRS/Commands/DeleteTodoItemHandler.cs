using MediatR;
using TodoApp.CQRS.Base;
using TodoApp.DataAccess.Repositories;

namespace TodoApp.CQRS.Commands
{
    public class DeleteTodoItemHandler : BaseTodoHandler, IRequestHandler<DeleteTodoItem, bool>
    {
        public DeleteTodoItemHandler(ILogger<DeleteTodoItemHandler> logger, ITodoRepository repository) : base(logger, repository)
        {
        }

        public async Task<bool> Handle(DeleteTodoItem request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
