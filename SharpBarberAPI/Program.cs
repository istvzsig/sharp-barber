using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddRazorPages();

// Register CORS services
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); // Adjust as needed
    });
});

var app = builder.Build();

List<Appointment> appointments = new();

app.UseStaticFiles();
app.UseCors();

app.MapGet("/", () => Results.File("index.html", "text/html"));

app.MapGet("/api/appointments", () => Results.Ok(appointments));

app.MapPost("/api/appointments", (Appointment appointment) =>
{
    if (appointment == null)
    {
        return Results.BadRequest("Invalid appointment data.");
    }
    appointments.Add(appointment);
    return Results.Ok("Appointment booked successfully.");
});

app.Run();

record Appointment(string Name, string Email, DateTime Date);
