using MediatR;
using TodoApp.DataAccess.Models;
using TodoApp.ViewModels;

namespace TodoApp.CQRS.Commands
{
    public class UpdateTodoItemCommand : TodoItem, IRequest<TodoViewModel>
    {
        public UpdateTodoItemCommand(TodoItem item)
        {
            this.Id = item.Id;
            this.Title = item.Title;
            this.Description = item.Description;
            this.Finished = item.Finished;
            this.Updated = DateTime.Now;
        }
    }
}
