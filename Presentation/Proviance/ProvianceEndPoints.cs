using Application.Proviance.Queries.GetAllProviance;
using Application.Proviance.Queries.GetByIdProviance;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Proviance
{
    public static class ProvianceEndPoints
    {
        public static void MapProvianceEndPoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("Proviance/GetAllProviance", [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
            async(IMediator _mediator, CancellationToken cancellationtoken) =>
            {
                try
                {
                    var query = new GetAllProvianceQuery();
                    var response = await _mediator.Send(query, cancellationtoken);
                    return response.IsSuccess ? Results.Ok(response.Data) : Results.NotFound(response.Errors);

                }catch (Exception ex)
                {
                    return Results.NotFound(ex.Message);
                }

            }
            ).WithTags("Proviance");

            app.MapGet("Proviance/GetProvianceByid", [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
            async(int Id, IMediator _mediator, CancellationToken cancellation) =>
            {
                try
                {
                    var query = new GetProvianceByIdQuery(Id);
                    var response = await _mediator.Send(query, cancellation);
                    return response.IsSuccess? Results.Ok(response.Data) : Results.NotFound(response?.Errors);


                }catch (Exception ex)
                {
                    return Results.BadRequest(ex.Message);
                }
            }
            ).WithTags("Proviance");

        }
    }
}
