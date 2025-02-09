using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SharpBarberAPI.Data;
using SharpBarberAPI.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=sharpbarber.db"));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "SharpBarber API", Version = "v1" });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseCors("AllowAllOrigins");

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();

    if (!context.Barbers.Any())
    {
        // Add dummy barbers
        context.Barbers.AddRange(
            new Barber { Name = "John Hairy", ImgUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Ftse2.mm.bing.net%2Fth%3Fid%3DOIP.eMjfMxVlYuzAcXkq7VoPcQAAAA%26pid%3DApi&f=1&ipt=b39635a9b774b53452266eef7c644b34f5e58f2aece28f1b6816f44f33fa961a&ipo=images" },
            new Barber { Name = "Super Mario", ImgUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Ftse1.mm.bing.net%2Fth%3Fid%3DOIP.5xurOceVymIXcglDe5ZUvAAAAA%26pid%3DApi&f=1&ipt=3a161bab345bacaf3f5e4ce0f4503fd47d11a0ef8514e5ee1fd95c9da785ed42&ipo=images" },
            new Barber { Name = "Nyissz Nyassz", ImgUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Ftse1.mm.bing.net%2Fth%3Fid%3DOIP.7ZOVa68CWitlK-8RwCfd-wAAAA%26pid%3DApi&f=1&ipt=51e683838e8db57896289258e8f1e0157bc63a8f457b60f6d2cf6193e95818a7&ipo=images" }
        );
        await context.SaveChangesAsync();
    }
}

app.Run();
