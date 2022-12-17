var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

//var port = Environment.GetEnvironmentVariable("PORT")??"8085";
var port = Environment.GetEnvironmentVariable("PORT")??"80";
app.MapGet("/", () =>
{
    app.Logger.LogInformation("Initial Home Get now");
    return "GET - Net 6 Running ... 06122022-v1.0.0 CI/CD in TRAVIS  Alexander Villalobos v1.0.0 AFORO255";
});

app.MapPost("/", () =>
{
    app.Logger.LogInformation("Initial Home Post");
    return "POST - Net 6 Running ... 06122022-v1.0.0 CI/CD in TRAVIS Alexander Villalobos v1.0.0 AFORO255";
});

app.Run($"http://0.0.0.0:{port}");

