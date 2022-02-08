using TodoApp.DataAccess.Repositories;

namespace TodoApp.CQRS.Base
{
    public class BaseTodoHandler : BaseHandler
    {
        protected ITodoRepository _todoRepository { get; init; }

        public BaseTodoHandler(ILogger<BaseTodoHandler> logger, ITodoRepository repository) : base(logger)
        {
            _todoRepository = repository;
        }
    }
}
