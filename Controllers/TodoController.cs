using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TodoApp.CQRS.Queries;
using TodoApp.DataAccess.Models;
using TodoApp.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
            var request = new TodoQuery();
            var result = await _mediator.Send(request);
            return result;
        }

        [HttpGet("{id}")]
        public async Task<TodoViewModel> Get(Guid id)
        {
            Response.StatusCode = (int)HttpStatusCode.NotFound;
            return new TodoViewModel();
        }

        [HttpPost]
        public async Task<TodoItem> Post([FromBody] TodoItem value)
        {
            Response.StatusCode = (int)HttpStatusCode.BadRequest;

            return value;
        }

        [HttpPut("{id}")]
        public async Task<TodoItem> Put(Guid id, [FromBody] TodoItem value)
        {

            Response.StatusCode = (int)HttpStatusCode.NotFound;
            return value;
        }

        [HttpDelete("{id}")]
        public async Task<Guid> Delete(Guid id)
        {
            Response.StatusCode = (int)HttpStatusCode.NotFound;
            return id;
        }
    }
}
