using MediatR;
using TodoApp.CQRS.Base;
using TodoApp.DataAccess.Repositories;
using TodoApp.ViewModels;

namespace TodoApp.CQRS.Commands
{
    public class UpdateTodoItemHandler : BaseTodoHandler, IRequestHandler<UpdateTodoItemCommand, TodoViewModel>
    {
        public UpdateTodoItemHandler(ILogger<UpdateTodoItemHandler> logger, ITodoRepository repository) : base(logger, repository)
        {
        }

        public async Task<TodoViewModel> Handle(UpdateTodoItemCommand request, CancellationToken cancellationToken)
        {
            var model = new TodoViewModel();
            model.TodoItems.Add(await _todoRepository.UpdateTodoItem(request));
            return model;
        }
    }
}
