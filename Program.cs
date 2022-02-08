using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApp.CQRS.Commands;
using TodoApp.CQRS.Queries;
using TodoApp.DataAccess.Context;
using TodoApp.DataAccess.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
});
builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
});

builder.Services.AddControllersWithViews();
builder.Services.AddMediatR(typeof(SingleTodoQuery), typeof(SingleTodoQueryHandler));
builder.Services.AddMediatR(typeof(FinishedTodoQuery), typeof(FinishedTodoQueryHandler));
builder.Services.AddMediatR(typeof(GetAllTodoQuery), typeof(GetAllTodoQueryHandler));
builder.Services.AddMediatR(typeof(AddTodoItemCommand), typeof(AddTodoItemHandler));
builder.Services.AddMediatR(typeof(DeleteTodoItemCommand), typeof(DeleteTodoItemHandler));
builder.Services.AddMediatR(typeof(UpdateTodoItemCommand), typeof(UpdateTodoItemHandler));


builder.Services.AddScoped<TodoContext, TodoContext>();
builder.Services.AddScoped<ITodoRepository, TodoRepository>();

builder.Services.AddDbContext<TodoContext>(options =>
{
    options.UseSqlite(sqliteOptions =>
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        var DbPath = Path.Join(path, "todo.db");
        options.UseSqlite($"Data Source={DbPath}");
        //C:\Users\%USER%\AppData\Local\todo.db
    });
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//-------------------------------------------------

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
