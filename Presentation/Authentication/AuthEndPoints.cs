using Application.Authentication.Commands.Login;
using Application.Authentication.Commands.Refresh_Token;
using Application.Authentication.Commands.Register;
using Domain.Abstraction;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Authentication
{
    public static class AuthEndPoints
    {
        public static void MapAuthEndPoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("Auth/login", async(IValidator<LoginRequest> validator, [FromBody] LoginRequest request, IMediator _mediator, CancellationToken cancellationToken) =>{
                try
                {
                    var validation = await validator.ValidateAsync(request);
                    if(!validation.IsValid)
                    {
                        return Results.ValidationProblem(validation.ToDictionary());
                    }
                    var command = new LoginCommand(request.username, request.password);

                    var tokenResult = await _mediator.Send(command, cancellationToken);

                    return tokenResult.IsSuccess ?
                    Results.Ok(tokenResult.Data) : Results.BadRequest(tokenResult.Errors);

                }catch (Exception ex)
                {
                    return Results.BadRequest(ex.Message);
                }

            }).WithTags("Authenticate");

            app.MapPost("Auth/register-user", async (IValidator<RegisterRequest> validator, [FromBody] RegisterRequest request, IMediator _mediator, CancellationToken cancellationtoken) =>
            {
                try
                {
                    var validation = await validator.ValidateAsync(request);
                    if(!validation.IsValid)
                    {
                        return Results.ValidationProblem(validation.ToDictionary());
                    }


                    var command = new RegisterCommand(request.username, request.email, request.password);

                    var result = await _mediator.Send(command, cancellationtoken);

                    return result.IsSuccess? Results.Created() : Results.BadRequest(result.Errors);

                }
                catch (Exception ex)
                {
                    return Results.BadRequest(ex.Message);
                }

            }).WithTags("Authenticate");

            app.MapPost("Auth/get-refresh-token", async ([FromBody] RefreshTokenRequest request, IMediator _mediator, CancellationToken cancellationToken) =>
            {
                try
                {
                    var command = new RefreshTokenCommand(request.token, request.refreshtoken);
                    var result = await _mediator.Send(command, cancellationToken);

                    return result.IsSuccess? Results.Ok(result.Data) : Results.BadRequest(result.Errors);

                }catch(Exception ex)
                {
                    return Results.BadRequest(ex.Message);
                }

            });

        }

    }
}
