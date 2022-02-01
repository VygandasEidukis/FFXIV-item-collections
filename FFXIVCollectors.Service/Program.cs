using FFXIVCollections.Infrastructure;
using FFXIVCollectors.Application;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration
    .AddJsonFile("appsettings.json")
    .Build();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddHttpClient();
builder.Services.AddLogging();
builder.Services.AddInfrastructure(configuration);
builder.Services.AddApplications();
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
