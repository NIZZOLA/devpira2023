using Microsoft.AspNetCore.Mvc;
using TravelMakerII.Contracts;
using TravelMakerII.Endpoints;
using TravelMakerII.Interfaces;
using TravelMakerII.Models;
using TravelMakerII.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
Console.WriteLine($"Environment: {builder.Environment.EnvironmentName}");
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<AzureAICredentials>(builder.Configuration.GetSection("AzureAICredentials"));

builder.Services.AddScoped<ITravelService, TravelService>();
builder.Services.AddScoped<IMechanicService, MechanicService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.AddTravelEndpoints();
app.AddMechanicEndpoints();

app.Run();
