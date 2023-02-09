using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Entities.Interfaces;
using Tienda.Repositories.EFCore.DataContext;
using Tienda.Repositories.EFCore.Repositories;
using Tienda.UseCases.Common.Bahaviors;
using Tienda.UseCases.CreateOrder;

namespace Tienda.InversionOfControl
{
    public static class DependencyContainer
    {
        public static WebApplicationBuilder AddTiendaService(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<TiendaContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("TiendaOphelia")));
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            builder.Services.AddScoped<IUnitiOfWork, UnitiOfWork>();
            builder.Services.AddMediatR(typeof(CreateOrderInteractor));
            builder.Services.AddValidatorsFromAssembly(typeof(CreateOrderValidator).Assembly);
            builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            return builder;
        }
    }
}
