using Microsoft.EntityFrameworkCore;
using ProxyService.Infrastructure;
using ProxyService.Services.Common;
using System.Diagnostics;
using ProxyService.Services;
using ProxyService.Services.Contracts;
using ProxyService.Services.Proxies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
foreach (var pair in ServicesCollector.Collect())
    builder.Services.AddScoped(pair.Item1, pair.Item2);
builder.Services.AddScoped(typeof(ITaskService), typeof(TaskService));
builder.Services.AddScoped(typeof(IProxyService), typeof(ProxyService.Services.Proxies.ProxyService));

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("TaskManagerdb"));

var app = builder.Build();
app.UseRouting();
app.MapControllers();
//// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();