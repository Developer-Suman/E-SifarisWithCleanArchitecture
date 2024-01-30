using Application.Abstraction;
using Application.Abstraction.EventBus;
using Application.Authentication.Commands.Register.RegisteredUser;
using Domain.Abstraction;
using Domain.Entities;
using Domain.IRepositories;
using Infrastructure.Cache;
using Infrastructure.Data;
using Infrastructure.JWT;
using Infrastructure.MessageBroker;
using Infrastructure.Repositories;
using Infrastructure.Seed;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class AssemblyReferences
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConn")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            #region Message Queue
            //Configure apsetting.json value to MessageBrokerSetting class
            services.Configure<MessageBrokerSettings>(
                configuration.GetSection("MessageBroker"));

            //Take the value from MEssageBroker Setting and inject to DependencyInjection
            services.AddSingleton(sp =>
            sp.GetRequiredService<IOptions<MessageBrokerSettings>>().Value) ;

            //Message queue are used to transport message using busConfiguration
            services.AddMassTransit(busConfigurator =>
            {
                //Add another configuration that provides configuration options for message bus for endpoint
                busConfigurator.SetKebabCaseEndpointNameFormatter();

                busConfigurator.AddConsumer<RegisteredCreatedEventConsumer>();

                busConfigurator.UsingRabbitMq((context, configurator) =>
                {
                    //Resolve message broke setting into variable
                    MessageBrokerSettings setings = context.GetRequiredService<MessageBrokerSettings>();

                    //Use this setting to connect to rabbitmq bus
                    configurator.Host(new Uri(setings.Host), h =>
                    {
                        h.Username(setings.Username);
                        h.Password(setings.Password);
                    });


                });
            });

            #endregion


            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ClockSkew = TimeSpan.Zero,
                        ValidIssuer = configuration["Jwt:Issuer"],
                        ValidAudience = configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!))

                    };

                });
            services.AddAuthorization();
            services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IJwtProvider, JwtProvider>();
            services.AddScoped<IMemoryCacheRepository, MemoryCacheRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddMemoryCache();
            services.AddTransient<DataSeeder>();
            services.AddScoped<IDistrictRepository, DistrictRepository>();
            services.AddScoped<IVDCRepository, VDCRepository>();
            services.AddScoped<IProvinceRepository, ProvinceRepository>();
            services.AddScoped<IinitializeRepository, InitializeRepository>();
            services.AddTransient<IEventBus, EventBus>();

            return services;
        }
    }
}
