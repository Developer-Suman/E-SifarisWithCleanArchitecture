using Application.District.Queries.GetAllDistrict;
using Application.District.Queries.GetDistrictById;
using Application.District.Queries.GetDistrictByProvianceId;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.District
{
    public static class DistrictEndPoints
    {
        public static void MapDistrictEndPoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("District/get-all-district", [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
            async (IMediator _mediator, CancellationToken cancellationToken) =>
            {
                try
                {
                    var query = new GetAllDistrictQuery();
                    var response = await _mediator.Send(query, cancellationToken);
                    return response.IsSuccess ? Results.Ok(response.Data) : Results.NotFound();
                }
                catch (Exception ex)
                {
                    return Results.NotFound(ex.Message);
                }

            }).WithTags("User");

            app.Map("District/getDistrict-by-Id", [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
            async (int Id, IMediator _mediator, CancellationToken cancellation) =>
            {
                try
                {
                    var query = new GetDistrictByIdQuery(Id);
                    var response = await _mediator.Send(query, cancellation);
                    return response.IsSuccess ? Results.Ok(response.Data) : Results.NotFound(response.Errors);

                }
                catch (Exception ex)
                {
                    return Results.BadRequest(ex.Message);

                }

            }).WithTags("District");

            app.MapGet("District/getdistrict-by-provianceId", [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
            async (int ProvianceId, IMediator mediator, CancellationToken cancellationtoken) =>
            {
                try
                {
                    var query = new GetDistrictByProvianceIdQuery(ProvianceId);
                    var response = await mediator.Send(query, cancellationtoken);
                    return response.IsSuccess? Results.Ok(response.Data) :Results.NotFound(response.Errors);

                }catch(Exception ex)
                {
                    return Results.BadRequest(ex.Message);
                }

            }).WithTags("District");

        }
    }
}
