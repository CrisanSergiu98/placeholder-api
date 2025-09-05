using Microsoft.AspNetCore.Authentication;
using Placeholder.Core;
using Placeholder.Data;
using PlaceHolder.Api.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddData();
builder.Services.AddCore();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseMiddleware<ApiKeyAuthenticationMiddleware>();
app.UseAuthorization();
app.MapControllers();

app.Run();