var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

List<Appointment> appointments = [];

// app.UseCors();

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
