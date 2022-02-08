namespace TodoApp.CQRS.Base
{
    public class BaseHandler
    {
        private ILogger<BaseHandler> _logger { get; init; }

        public BaseHandler(ILogger<BaseHandler> logger)
        {
            _logger = logger;
        }
    }
}
