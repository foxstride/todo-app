using MediatR;
using TodoApp.CQRS.Base;
using TodoApp.DataAccess.Repositories;
using TodoApp.ViewModels;

namespace TodoApp.CQRS.Queries
{
    public class GetAllTodoQueryHandler : BaseTodoHandler, IRequestHandler<GetAllTodoQuery, TodoViewModel>
    {
        public GetAllTodoQueryHandler(ILogger<GetAllTodoQueryHandler> logger, ITodoRepository repository) : base(logger, repository)
        {
        }

        public async Task<TodoViewModel> Handle(GetAllTodoQuery request, CancellationToken cancellationToken)
        {
            var model = new TodoViewModel()
            {
                TodoItems = (await _todoRepository.GetTodoItems()).Where(request.Predicate).ToList()
            };
            
            return model;
        }
    }
}
