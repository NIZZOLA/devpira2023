using Microsoft.AspNetCore.Mvc;
using SampleApiImageGenAi;
using SampleApiImageGenAi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IOpenAiImageService, OpenAiImageService>();
builder.Services.Configure<AzureAICredentials>(builder.Configuration.GetSection("AzureAICredentials"));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("generateimage", async ([FromServices] IOpenAiImageService service, [FromBody] string description) =>
{
    return await service.GenerateImageFromAi(description);
});

app.Run();
