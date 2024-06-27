using FluentValidation;
using MyFirstAspireApp.ApiService.Shared;
using MyFirstAspireApp.ApiService.WeatherForecasts;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire components.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();

builder.Services.AddMediatR(config =>
                                {
                                    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
                                    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
                                });

builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

app.MapWeatherForecastEndpoints();

app.MapDefaultEndpoints();

await app.RunAsync().ConfigureAwait(true);