// ------------------------------------------------------------------------------
//  <copyright file="CreateWeatherForecastCommand.cs" company="MY-LEX b.v.">
//      Copyright (c) MY-LEX b.v., The Netherlands. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------

using MyFirstAspireApp.ApiService.Shared;

namespace MyFirstAspireApp.ApiService.WeatherForecasts
{
    public record CreateWeatherForecastCommand(WeatherForecast Forecast) : ICommand<CreateWeatherForecastResponse>;
}