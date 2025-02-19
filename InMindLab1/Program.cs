using InMindLab1.Filters;
using InMindLab1.Middleware;
using InMindLab1.Services;
using InMindLab1.Services.StudentServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.OData;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton<IStudentService, StudentService>();
builder.Services.AddSingleton<RequestLoggingMiddleware>();
builder.Services.AddScoped<ILoggerActionFilter>();
builder.Services.AddControllers(options =>
{
options.Filters.Add<LoggingActionFilter>();
});

builder.Services.AddScoped<LoggingActionFilter>();
builder.Services.AddSingleton<ObjectMapperService>();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>(); 
builder.Services.AddProblemDetails();
builder.Services.AddSingleton<ILibraryService, LibraryService>();
builder.Services.AddControllers().AddOData(opt =>
opt.Select().Filter().OrderBy().Count());
var app = builder.Build();


app.UseStaticFiles();
if (app.Environment.IsDevelopment())
{

}
app.UseExceptionHandler();

app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.UseMiddleware<RequestLoggingMiddleware>();

app.Run();