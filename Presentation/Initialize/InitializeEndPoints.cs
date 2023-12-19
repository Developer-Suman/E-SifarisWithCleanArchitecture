using Application.Inatiallize.Command.Inatilize;
using Application.Inatiallize.Queries.CheckInitillize;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
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

            app.MapPost("Initialize/initialize-system", async (IValidator<InitializeRequest> validator, [FromForm] InitializeRequest initializeRequest, HttpContext context) =>
            {
                try
                {
 
                    var validation = await validator.ValidateAsync(initializeRequest);
                    if (!validation.IsValid)
                    {
                        return Results.ValidationProblem(validation.ToDictionary());
                    }


                    return Results.Ok();

                }
                catch (Exception ex)
                {
                    return Results.BadRequest(ex.Message);
                }

            }).WithTags("Initiallize");

            app.MapGet("token/antiforgerytoken", (IAntiforgery antiforgery, HttpContext context) =>
            {
                var token = antiforgery.GetAndStoreTokens(context);
                var xsref = token.RequestToken!;
                return TypedResults.Content(xsref, "text/plain");

            }).WithTags("AntiforgeryToken");


            app.MapGet("Initiallize/CheckInitiallize", async (IMediator mediator, CancellationToken cancellationtoken) =>
            {
                try
                {
                    var query = new CheckInitillizeQuery();
                    var response  =await mediator.Send(query, cancellationtoken);
                    return response.IsSuccess? Results.Ok(response.IsSuccess) : Results.BadRequest(response?.Errors);

                }catch(Exception ex)
                {
                    return Results.BadRequest(ex.Message);
                }

            }).WithTags("Initiallize");

            

        }
    }
}
