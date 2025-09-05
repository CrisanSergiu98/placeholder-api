namespace PlaceHolder.Api.Middleware;

public class ApiKeyAuthenticationMiddleware
{
    private readonly RequestDelegate _next;

    private const string APIKEY_HEADER = "X-API-Key";
    public ApiKeyAuthenticationMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task InvokeAsync(HttpContext context)
    {
        // Check if key exists and put it in a variable
        if (!context.Request.Headers.TryGetValue(APIKEY_HEADER, out var extractedApiKey))
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("API Key was not provided");
            return;
        }

        // Get expected API Key from configuration
        var config = context.RequestServices.GetRequiredService<IConfiguration>();
        var apiKey = config.GetValue<string>(APIKEY_HEADER);

        // Check the keys against each other
        if (!apiKey.Equals(extractedApiKey))
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Unauthorized client");
            return;
        }

        // Return next middleware
        await _next(context);
    }
}