using SharpBarberAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add CORS configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", policy =>
    {
        policy.WithOrigins("http://localhost:4200")  // Allows all origins (not recommended for production)
              .AllowAnyMethod()  // Allows any HTTP methods (GET, POST, PUT, etc.)
              .AllowAnyHeader(); // Allows any headers
    });
});

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Use CORS middleware
app.UseCors("AllowAllOrigins");  // Use the policy to allow cross-origin requests

// Dummy barbers
List<Barber> barbers = [
    new Barber {Id = 1, Name = "John Hairy", ImgUrl = ""},
    new Barber {Id = 2, Name = "Super Mario", ImgUrl = ""},
    new Barber {Id = 3, Name = "Nyissz Nyassz", ImgUrl = ""},
];

app.MapGet("/api/barbers", () => Results.Ok(barbers));

app.Run();
