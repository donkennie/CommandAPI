using CommandAPI.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddNewtonsoftJson(s =>
{
    s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
});

builder.Services.AddScoped<ICommandAPIRepo, MockCommandAPIRepo>();

builder.Services.AddScoped<ICommandAPIRepo, SqlCommandAPIRepo>();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<CommandContext>(opt =>
{
    opt.UseSqlServer(connectionString);
});

//builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

//app.UseRouting();

app.MapControllers();
//app.MapGet("/", () => "Hello World!");

app.Run();
