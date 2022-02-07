using MediatR;
using TodoApp.ViewModels;

namespace TodoApp.CQRS.Queries
{
    public class TodoQuery : IRequest<TodoViewModel>
    {
        public Guid Id { get; set; }
        public bool Finished { get; set; }
    }
}
