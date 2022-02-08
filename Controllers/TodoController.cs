using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TodoApp.CQRS.Commands;
using TodoApp.CQRS.Queries;
using TodoApp.DataAccess.Models;
using TodoApp.ViewModels;

namespace TodoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private ILogger<TodoController> _logger { get; init; }
        private IMediator _mediator { get; init; }
        public TodoController(ILogger<TodoController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<TodoViewModel> Get()
        {
            var request = new GetAllTodoQuery();
            var result = await _mediator.Send(request);

            if (result.TodoItems.Count == 0)
                Response.StatusCode = (int)HttpStatusCode.NotFound;

            return result;
        }

        [HttpGet("{id}")]
        public async Task<TodoViewModel> Get(Guid id)
        {
            var request = new SingleTodoQuery() { Id = id };
            var result = await _mediator.Send(request);

            if (result.TodoItems.FirstOrDefault()?.Id == Guid.Empty)
                Response.StatusCode = (int)HttpStatusCode.NotFound;

            return result;
        }

        [HttpPost]
        public async Task<TodoViewModel> Post([FromBody] TodoItem value)
        {
            try
            {
                var command = new AddTodoItemCommand(value);
                var result = await _mediator.Send(command);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(TodoController)}.{nameof(Post)}");
                return new TodoViewModel();
            }
        }

        [HttpPut("{id}")]
        public async Task<TodoViewModel> Put(Guid id, [FromBody] TodoItem value)
        {
            try
            {
                if (value.Id == Guid.Empty) value.Id = id;
                var command = new UpdateTodoItemCommand(value);
                var result = await _mediator.Send(command);

                if (result.TodoItems.FirstOrDefault()?.Id == Guid.Empty)
                    Response.StatusCode = (int)HttpStatusCode.NotFound;

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(TodoController)}.{nameof(Put)}");
                return new TodoViewModel();
            }
        }

        [HttpDelete("{id}")]
        public async Task<Guid> Delete(Guid id)
        {
            var command = new DeleteTodoItemCommand() { Id = id };
            var deleted = await _mediator.Send(command);

            if (!deleted)
                Response.StatusCode = (int)HttpStatusCode.NotFound;
            
            return deleted ? id : Guid.Empty;
        }
    }
}
