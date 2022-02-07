using MediatR;
using TodoApp.ViewModels;

namespace TodoApp.CQRS.Commands
{
    public class AddTodoItemHandler : IRequestHandler<AddTodoItem, TodoViewModel>
    {
        Task<TodoViewModel> IRequestHandler<AddTodoItem, TodoViewModel>.Handle(AddTodoItem request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
