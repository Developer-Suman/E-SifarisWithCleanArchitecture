using Application.Inatiallize.Command.Inatilize;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Initialize
{
    public static class InitializeEndPoints
    {
        public static void MapInitializeEndPoints(this IEndpointRouteBuilder app)
        {

            app.MapPost("Initialize/initialize-system", async(IValidator < InitializeRequest > validator, [FromForm] InitializeRequest initializeRequest) =>
            {
                try
                {
                    var validation = await validator.ValidateAsync(initializeRequest);
                    if(!validation.IsValid)
                    {
                        return Results.ValidationProblem(validation.ToDictionary());
                    }
                    return Results.Ok();

                }catch (Exception ex)
                {
                    return Results.BadRequest(ex.Message);
                }

            }).WithTags("Initializer");

        }
    }
}
