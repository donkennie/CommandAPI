using CommandAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICommandAPIRepo, MockCommandAPIRepo>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<StoreContext>(opt =>
{
    opt.UseSqlServer(connectionString);
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
