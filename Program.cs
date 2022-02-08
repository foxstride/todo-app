using MediatR;
using Microsoft.EntityFrameworkCore;
using TodoApp.CQRS.Queries;
using TodoApp.DataAccess.Context;
using TodoApp.DataAccess.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddControllersWithViews();
builder.Services.AddMediatR(typeof(TodoQuery), typeof(TodoQueryHandler));

builder.Services.AddScoped<ITodoContext, TodoContext>();
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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");;

app.Run();
