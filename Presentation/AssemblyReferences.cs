using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Authentication;
using Presentation.District;
using Presentation.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    public static class AssemblyReferences
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddAntiforgery(options => options.HeaderName = "X-CSRF-TOKEN");
            return services;
        }

        public static IEndpointRouteBuilder AddEndPoint(this IEndpointRouteBuilder builder)
        {
            builder.MapUserEndPoints();
            builder.MapAuthEndPoints();
            builder.MapDistrictEndPoints();
            return builder;

        }
    }
}
