using Microsoft.AspNetCore.Mvc;
using TravelMakerII.Contracts;
using TravelMakerII.Interfaces;

namespace TravelMakerII.Endpoints;

public static class TravelEndpoints
{
    public static void AddTravelEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/travel").WithTags("Travel");
        group.MapPost("/itinerary", (ITravelService _service, [FromBody] ItineraryRequestModel request) =>
        {
            if (string.IsNullOrEmpty(request.Name) || request.days == 0)
            {
                return Results.BadRequest("Preencha todos os campos na requisição");
            }
            var result = _service.GetItinerary(request);
            if (result is not null)
                return Results.Ok(result);
            return Results.NotFound();
        })
        .WithName("GetItinerary")
        .WithOpenApi();

        group.MapPost("/placeinformation", (ITravelService _service, [FromBody] PlaceInformationRequestModel request) =>
        {
            if (string.IsNullOrEmpty(request.PlaceName) || string.IsNullOrEmpty(request.GeoReference))
            {
                return Results.BadRequest("Preencha todos os campos na requisição");
            }
            var result = _service.GetPlaceInformation(request);
            if (result is not null)
                return Results.Ok(result);
            return Results.NotFound();
        })
        .WithName("GetPlaceInfo")
        .WithOpenApi();
    }
}
