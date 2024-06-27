// ------------------------------------------------------------------------------
//  <copyright file="WeatherForecastWebApplicationExtensions.cs" company="MY-LEX b.v.">
//      Copyright (c) MY-LEX b.v., The Netherlands. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------

namespace MyFirstAspireApp.ApiService.WeatherForecasts;

using MediatR;

using Microsoft.AspNetCore.Mvc;

internal static class WeatherForecastWebApplicationExtensions
{
    public static WebApplication MapCreateWeatherForecast(this WebApplication application)
    {
        application
            .MapPost(
                pattern: "/weatherforecast",
                handler: async ([FromServices] ISender sender, [FromBody] WeatherForecast forecast, CancellationToken cancellationToken) =>
                             {
                                 var result = await sender.Send(new CreateWeatherForecastCommand(forecast), cancellationToken).ConfigureAwait(false);

                                     return Results.CreatedAtRoute(
                                         routeName: nameof(MapGetWeatherForecast),
                                         routeValues: new { id = result.Id },
                                         value: result);
                             })
            .WithName(nameof(MapCreateWeatherForecast));

        return application;
    }

    public static WebApplication MapGetWeatherForecast(this WebApplication application)
    {
        application
            .MapGet("/weatherforecast/{id}", (Guid id) => new WeatherForecast(id, DateOnly.FromDateTime(DateTime.Now), 12, $"Forecast {id}"))
            .WithName(nameof(MapGetWeatherForecast));
        return application;
    }

    public static WebApplication MapGetWeatherForecasts(this WebApplication application)
    {
        var summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };

        application
            .MapGet(
                "/weatherforecast",
                () =>
                    {
                        var forecast = Enumerable
                            .Range(1, 5)
                            .Select(
                                index => new WeatherForecast(
                                    Guid.NewGuid(),
                                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                                    Random.Shared.Next(-20, 55),
                                    summaries[Random.Shared.Next(summaries.Length)]))
                            .ToArray();
                        return forecast;
                    })
            .WithName(nameof(MapGetWeatherForecasts));
        return application;
    }

    public static WebApplication MapWeatherForecastEndpoints(this WebApplication application)
    {
        return application.MapCreateWeatherForecast().MapGetWeatherForecasts().MapGetWeatherForecast();
    }
}