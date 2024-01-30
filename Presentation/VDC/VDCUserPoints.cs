using Application.VDC.Queries.GetAllVDC;
using Application.VDC.Queries.GetByIdVDC;
using Application.VDC.Queries.GetVDCByDistrict;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.VDC
{
    public static class VDCUserPoints
    {
        public static void MapVDCEndPoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("VDC/getAllVDC", async (IMediator mediator, CancellationToken cancellationtoken) =>
            {
                try
                {
                    var query = new GetAllVDCQuery();
                    var response = await mediator.Send(query, cancellationtoken);
                    return response.IsSuccess? Results.Ok(response.Data) : Results.NotFound();

                }catch (Exception ex)
                {
                    return Results.BadRequest(ex.Message);
                }

            }).WithTags("VDC");

            app.MapGet("VDC/get-by-districtId", async (int districtId, IMediator mediator, CancellationToken cancellationtoken) =>
            {
                try
                {
                    var query = new GetVDCByDistrictidQuery(districtId);
                    var response = await mediator.Send(query, cancellationtoken);
                    return response.IsSuccess? Results.Ok(response.Data): Results.NotFound();

                }catch (Exception ex)
                {
                    return Results.BadRequest(ex.Message);
                }

            }).WithTags("VDC");

            app.MapGet("VDC/get-by-id", async (int VDCId, IMediator mediator, CancellationToken cancellationtoken) =>
            {
                try
                {
                    var query = new GetVDCByIdQuery(VDCId);
                    var response = await mediator.Send(query, cancellationtoken);
                    return response.IsSuccess? Results.Ok(response.Data) : Results.NotFound();

                }catch (Exception ex)
                {
                    return Results.BadRequest(ex.Message);
                }

            }).WithTags("VDC");
        }
    }
}
