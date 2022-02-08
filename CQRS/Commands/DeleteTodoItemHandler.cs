using MediatR;
using TodoApp.CQRS.Base;
using TodoApp.DataAccess.Repositories;

namespace TodoApp.CQRS.Commands
{
    public class DeleteTodoItemHandler : BaseTodoHandler, IRequestHandler<DeleteTodoItemCommand, bool>
    {
        public DeleteTodoItemHandler(ILogger<DeleteTodoItemHandler> logger, ITodoRepository repository) : base(logger, repository)
        {
        }

        public async Task<bool> Handle(DeleteTodoItemCommand request, CancellationToken cancellationToken)
        {
            return await _todoRepository.DeleteTodoItem(request.Id);
        }
    }
}
