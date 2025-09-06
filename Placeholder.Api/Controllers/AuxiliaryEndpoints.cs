using Microsoft.AspNetCore.Mvc;
using Placeholder.Domain.Abstractions;

namespace PlaceHolder.Api.Controllers;

public static class AuxiliaryEndpoints
{
    public static void MapAuxiliaryEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/phones", async ([FromHeader(Name = "X-API-Key")] string apiKey, int quantity, IProfilesService service) =>
        {
            var phones = await service.GetRandomPhoneNumbers(quantity);
            return Results.Ok(phones);
        });

        app.MapGet("/emails", async ([FromHeader(Name = "X-API-Key")] string apiKey, int quantity, IProfilesService service) =>
        {
            var emails = await service.GetRandomEmails(quantity);
            return Results.Ok(emails);
        });

        app.MapGet("/dob", async ([FromHeader(Name = "X-API-Key")] string apiKey, int quantity, IProfilesService service) =>
        {
            var dobs = await service.GetRandomDobs(quantity);
            return Results.Ok(dobs);
        });

        app.MapGet("/names", async ([FromHeader(Name = "X-API-Key")] string apiKey, int quantity, IProfilesService service) =>
        {
            var names = await service.GetRandomNames(quantity);
            return Results.Ok(names);
        });
    }
}