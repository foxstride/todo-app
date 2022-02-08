using MediatR;
using TodoApp.CQRS.Base;
using TodoApp.DataAccess.Repositories;
using TodoApp.ViewModels;

namespace TodoApp.CQRS.Commands
{
    public class AddTodoItemHandler : BaseTodoHandler, IRequestHandler<AddTodoItem, TodoViewModel>
    {
        public AddTodoItemHandler(ILogger<AddTodoItemHandler> logger, ITodoRepository repository) : base(logger, repository)
        {
        }

        public async Task<TodoViewModel> Handle(AddTodoItem request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
