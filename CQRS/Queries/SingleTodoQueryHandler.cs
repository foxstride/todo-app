using MediatR;
using TodoApp.CQRS.Base;
using TodoApp.DataAccess.Repositories;
using TodoApp.ViewModels;

namespace TodoApp.CQRS.Queries
{
    public class SingleTodoQueryHandler : BaseTodoHandler, IRequestHandler<SingleTodoQuery, TodoViewModel>
    {
        public SingleTodoQueryHandler(ILogger<SingleTodoQueryHandler> logger, ITodoRepository repository) : base(logger, repository)
        {
        }

        public async Task<TodoViewModel> Handle(SingleTodoQuery request, CancellationToken cancellationToken)
        {
            var model = new TodoViewModel();
            model.TodoItems.Add((await _todoRepository.GetTodoItem(request.Id)));
            return model;
        }
    }
}
