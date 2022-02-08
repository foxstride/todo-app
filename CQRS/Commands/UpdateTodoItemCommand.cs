﻿using MediatR;
using TodoApp.DataAccess.Models;
using TodoApp.ViewModels;

namespace TodoApp.CQRS.Commands
{
    public class UpdateTodoItemCommand : TodoItem, IRequest<TodoViewModel>
    {
    }
}