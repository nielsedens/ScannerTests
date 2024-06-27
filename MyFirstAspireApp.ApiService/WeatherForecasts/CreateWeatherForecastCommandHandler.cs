// ------------------------------------------------------------------------------
//  <copyright file="CreateWeatherForecastCommandHandler.cs" company="MY-LEX b.v.">
//      Copyright (c) MY-LEX b.v., The Netherlands. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------

namespace MyFirstAspireApp.ApiService.WeatherForecasts;

internal class CreateWeatherForecastCommandHandler : ICreateWeatherForecastCommandHandler
{
    /// <inheritdoc />
    public Task<CreateWeatherForecastResponse> Handle(CreateWeatherForecastCommand request, CancellationToken cancellationToken)
    {
        // Do the business logic that would normally be done in a class named `WeatherForecastProvider`. In this case store the
        // weather forecast in the database if it does not already exist.

        return Task.FromResult(new CreateWeatherForecastResponse(Guid.NewGuid()));
    }
}