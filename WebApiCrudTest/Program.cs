using CleanArch.Application.Query;
using CleanArch.Infra.Data.Context;
using CleanArch.Infra.IoC;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionStringMysql = builder.Configuration.GetConnectionString("MySQLDatabase");
builder.Services.AddDbContext<CRUDContext>(options =>
{
    options.UseMySql(connectionStringMysql, ServerVersion.AutoDetect(connectionStringMysql));
});
RegisterServices(builder.Services);
builder.Services.AddMediatR(typeof(GetAllCustomersQuery));
builder.Services.AddMediatR(typeof(GetCustomerByIdQuery).GetTypeInfo().Assembly);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


 static void RegisterServices(IServiceCollection services)
{
    DependencyContainer.RegisterServices(services);
}