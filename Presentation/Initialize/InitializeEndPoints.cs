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

            app.MapPost("Initialize/initialize-system", async (IValidator<InitializeRequest> validator, [FromBody] InitializeRequest initializeRequest, IMediator mediatr, CancellationToken cancellationToken) =>
            {
                try
                {
                   
 
                    var validation = await validator.ValidateAsync(initializeRequest);
                    if (!validation.IsValid)
                    {
                        return Results.ValidationProblem(validation.ToDictionary());
                    }

                    var command = new InitializeCommand(
                        initializeRequest.BranchNameInNepali,
                        initializeRequest.BranchNameInEnglish,
                        initializeRequest.provianceId,
                        initializeRequest.districtId,
                        initializeRequest.localGovernment,
                        initializeRequest.addressInEnglish,
                        initializeRequest.addressInNepali,
                        initializeRequest.branchContactInEnglish,
                        initializeRequest.branchContactInNepali,
                        initializeRequest.officeHead,
                        initializeRequest.basicInformation,
                        initializeRequest.logoURL,
                        initializeRequest.headerInEnglish,
                        initializeRequest.headerInNepali,
                        initializeRequest.footerInEnglish,
                        initializeRequest.footerInNepali,
                        initializeRequest.watermarkURL,
                        initializeRequest.branchTypeId,
                        initializeRequest.wardId,
                        initializeRequest.departmentId,
                        initializeRequest.municipalityId,
                        initializeRequest.vDCId,
                        initializeRequest.isActive
                        );

                    var result = await mediatr.Send(command, cancellationToken);
                    return result.IsSuccess ? Results.Ok(result.Data) : Results.BadRequest(result.Errors);


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
                    return response.IsSuccess? Results.Ok(response.IsSuccess) : Results.BadRequest(response.Errors);

                }catch(Exception ex)
                {
                    return Results.BadRequest(ex.Message);
                }

            }).WithTags("Initiallize");

            

        }
    }
}
