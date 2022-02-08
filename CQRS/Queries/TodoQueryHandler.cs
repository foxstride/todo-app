using MediatR;
using TodoApp.CQRS.Base;
using TodoApp.DataAccess.Repositories;
using TodoApp.ViewModels;

namespace TodoApp.CQRS.Queries
{
    public class TodoQueryHandler : BaseTodoHandler, IRequestHandler<TodoQuery, TodoViewModel>
    {
        public TodoQueryHandler(ILogger<TodoQueryHandler> logger, ITodoRepository repository) : base(logger, repository)
        {
        }

        public async Task<TodoViewModel> Handle(TodoQuery request, CancellationToken cancellationToken)
        {
            var model = new TodoViewModel
            {
                TodoItems = await _todoRepository.GetTodoItems()
            };

            return model;
        }
    }
}
