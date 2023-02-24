using Microsoft.AspNetCore.Identity;
using VoidAggregator.Bl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var services = builder.Services;

services.AddServices(builder.Configuration);

services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

using(var serviceScope = (app as IApplicationBuilder).ApplicationServices.GetService<IServiceScopeFactory>()!.CreateScope())
{
	serviceScope.TryAddDb();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
