using SharpBarberAPI.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Dummy barbes
List<Barber> barbers = [
    new Barber {Id = 1, Name = "John Hairy", ImgUrl = ""},
    new Barber {Id = 2, Name = "Super Mario", ImgUrl = ""},
    new Barber {Id = 3, Name = "Nyissz Nyassz", ImgUrl = ""},
];


app.MapGet("/api/barbers", () => Results.Ok(barbers));

app.Run();