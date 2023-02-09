using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Tienda.Entities.Exceptions;
using Tienda.Repositories.EFCore.DataContext;
using Tienda.WebExceptionsPresenter;
using Tienda.InversionOfControl;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddControllers(options =>
    options.Filters.Add(new ApiExceptionFilterAttribute(
        new Dictionary<Type, IExceptionHandler>
        {
            { typeof(GeneralException), new GeneralExceptionHandler() },
            { typeof(ValidationException), new ValidationExceptionHandler() }
        })));
builder.AddTiendaService();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Tienda", Version = "v1" });
});

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
