using MediatR;
using TodoApp.DataAccess.Models;
using TodoApp.ViewModels;

namespace TodoApp.CQRS.Commands
{
    public class AddTodoItemCommand : TodoItem, IRequest<TodoViewModel>
    {
        
    }
}
