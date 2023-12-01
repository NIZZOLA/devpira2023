using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TravelMakerII.Interfaces;
using TravelMakerII.Models;

namespace TravelMakerII.Endpoints;

public static class MechanicEndpoints
{
    public static void AddMechanicEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/mechanic").WithTags("mechanichelp");

        group.MapPost("", (IMechanicService _service, [FromBody] ProblemsRequestModel request) =>
        {
            if (string.IsNullOrEmpty(request.Problem) || string.IsNullOrEmpty(request.VehicleModel))
            {
                return Results.BadRequest("Preencha todos os campos na requisição");
            }
            var result = _service.GetMechanic(request);
            if (result is not null)
                return Results.Ok(result);
            return Results.NotFound();
        })
        .WithName("GetMechanicHelp")
        .WithOpenApi();
    }

}
