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
            return result;
        }

        [HttpGet("{id}")]
        public async Task<TodoViewModel> Get(Guid id)
        {
            var request = new SingleTodoQuery() { Id = id };
            var result = await _mediator.Send(request);
            return result;
        }

        [HttpPost]
        public async Task<TodoViewModel> Post([FromBody] TodoItem value)
        {
            var command = (AddTodoItemCommand)value;
            var result = await _mediator.Send(command);
            return result;
        }

        [HttpPut("{id}")]
        public async Task<TodoViewModel> Put([FromBody] TodoItem value)
        {
            var command = (UpdateTodoItemCommand)value;
            var result = await _mediator.Send(command);
            return result;
        }

        [HttpDelete("{id}")]
        public async Task<Guid> Delete(Guid id)
        {
            var command = new DeleteTodoItemCommand() { Id = id };
            var result = await _mediator.Send(command);
            
            return result ? id : Guid.Empty;
        }
    }
}
