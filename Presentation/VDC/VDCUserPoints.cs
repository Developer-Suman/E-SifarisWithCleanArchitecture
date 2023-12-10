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

            }).WithTags("VDC");

            app.MapGet("VDC/get-by-districtId", async (int districtId, IMediator mediator, CancellationToken cancellationtoken) =>
            {

            }).WithTags("VDC");

            app.MapGet("VDC/get-by-id", async (int VDCId, IMediator mediator, CancellationToken cancellationtoken) =>
            {

            }).WithTags("VDC");
        }
    }
}
