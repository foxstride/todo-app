using MediatR;
using TodoApp.DataAccess.Models;
using TodoApp.ViewModels;

namespace TodoApp.CQRS.Commands
{
    public class AddTodoItemCommand : TodoItem, IRequest<TodoViewModel>
    {
        public AddTodoItemCommand(TodoItem item)
        {
            this.Title = item.Title;
            this.Description = item.Description;
            this.Finished = item.Finished;
            this.Created = DateTime.Now;
            this.Updated = DateTime.Now;
        }
    }
}
