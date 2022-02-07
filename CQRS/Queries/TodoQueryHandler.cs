using MediatR;
using TodoApp.DataAccess.Repositories;
using TodoApp.ViewModels;

namespace TodoApp.CQRS.Queries
{
    public class TodoQueryHandler : IRequestHandler<TodoQuery, TodoViewModel>
    {
        private ILogger<TodoQueryHandler> _logger { get; init; }
        private ITodoRepository _repository { get; init; }

        public TodoQueryHandler(ILogger<TodoQueryHandler> logger, ITodoRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<TodoViewModel> Handle(TodoQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
