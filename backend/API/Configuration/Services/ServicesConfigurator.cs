using System;
using System.Text;
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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
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
            services.AddScoped<IAgentRepository, AgentRepository>();

            var key = Encoding.ASCII
                .GetBytes(configuration.GetSection("Authentication").GetSection("secretKey").Value);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Agent", policy => { policy.RequireClaim("agent", "1"); });
                options.AddPolicy("Customer", policy => { policy.RequireClaim("customer", "1"); });
                options.AddPolicy("Authenticated", policy => { policy.RequireAuthenticatedUser(); });

                options.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build());
            });

            services.AddSwaggerGen(options =>
            {
                options.CustomSchemaIds(type => type.ToString());
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Bantix API", Version = "v1" });
            });
        }
    }
}