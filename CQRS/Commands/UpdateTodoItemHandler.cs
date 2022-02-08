using MediatR;
using TodoApp.CQRS.Base;
using TodoApp.DataAccess.Repositories;
using TodoApp.ViewModels;

namespace TodoApp.CQRS.Commands
{
    public class UpdateTodoItemHandler : BaseTodoHandler, IRequestHandler<UpdateTodoItem, TodoViewModel>
    {
        public UpdateTodoItemHandler(ILogger<UpdateTodoItemHandler> logger, ITodoRepository repository) : base(logger, repository)
        {
        }

        public async Task<TodoViewModel> Handle(UpdateTodoItem request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
