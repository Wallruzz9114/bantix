using System;
using Core.Services.Implementations;
using Core.Services.Interfaces;
using Data;
using Data.Repositories.Implementations;
using Data.Repositories.Interfaces;
using Libraries.Abstraction.Handlers;
using Libraries.Abstraction.Implementations;
using Libraries.Abstraction.Interfaces;
using Libraries.Abstraction.Notifications;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace API.Configuration.Services
{
    public class ServicesConfigurator : IServicesConfigurator
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();

            services.AddDbContext<AppDbContext>(options => options
                .UseNpgsql(configuration.GetConnectionString("DatabaseConnection")));

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<IUserService, UserService>();
            services.AddMediatR(typeof(Startup));
            services.AddScoped<INotificationHandler<EntityNotification>, EntityNotificationHandler>();
            services.AddScoped<IAgencyRepository, AgencyRepository>();

            services.AddSwaggerGen(options =>
            {
                options.CustomSchemaIds(type => type.ToString());
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Bantix API", Version = "v1" });
            });
        }
    }
}