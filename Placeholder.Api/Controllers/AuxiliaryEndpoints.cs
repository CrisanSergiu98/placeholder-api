using Microsoft.AspNetCore.Mvc;
using Placeholder.Domain.Abstractions;

namespace PlaceHolder.Api.Controllers;

public static class AuxiliaryEndpoints
{
    public static void MapAuxiliaryEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/phones", ([FromHeader(Name = "X-API-Key")] string apiKey, int quantity, IProfilesService service) =>
        {
            var phones = service.GetRandomPhoneNumbers(quantity);
            return Results.Ok(phones);
        });

        app.MapGet("/emails", ([FromHeader(Name = "X-API-Key")] string apiKey, int quantity, IProfilesService service) =>
        {
            var emails = service.GetRandomEmails(quantity);
            return Results.Ok(emails);
        });

        app.MapGet("/dob", ([FromHeader(Name = "X-API-Key")] string apiKey, int quantity, IProfilesService service) =>
        {
            var dobs = service.GetRandomDobs(quantity);
            return Results.Ok(dobs);
        });
    }
}