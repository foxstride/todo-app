using MediatR;
using TodoApp.CQRS.Base;
using TodoApp.DataAccess.Repositories;
using TodoApp.ViewModels;

namespace TodoApp.CQRS.Queries
{
    public class UnfinishedTodoQueryHandler : BaseTodoHandler, IRequestHandler<UnfinishedTodoQuery, TodoViewModel>
    {
        public UnfinishedTodoQueryHandler(ILogger<FinishedTodoQueryHandler> logger, ITodoRepository repository) : base(logger, repository)
        {
        }

        public async Task<TodoViewModel> Handle(UnfinishedTodoQuery request, CancellationToken cancellationToken)
        {
            var result = new TodoViewModel()
            {
                TodoItems = (await _todoRepository.GetTodoItems(x => !x.Finished)).Where(request.Predicate).ToList()
            };

            return result;
        }
    }
}
