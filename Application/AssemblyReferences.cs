using Application.Authentication.Commands.Login;
using Application.Authentication.Commands.Register;
using Application.Inatiallize.Command.Inatilize;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class AssemblyReferences
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IValidator<InitializeRequest>, InitializeRequestValidator>();
            services.AddScoped<IValidator<RegisterRequest>, RegisterRequestValidator>();
            services.AddScoped<IValidator<LoginRequest>, LogInRequestValidator>();
            services.AddMediatR(x => x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            return services;
        }
    }
}
