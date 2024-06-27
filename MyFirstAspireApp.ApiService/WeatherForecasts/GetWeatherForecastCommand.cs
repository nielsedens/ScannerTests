// ------------------------------------------------------------------------------
//  <copyright file="GetWeatherForecastCommand.cs" company="MY-LEX b.v.">
//      Copyright (c) MY-LEX b.v., The Netherlands. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------

namespace MyFirstAspireApp.ApiService.WeatherForecasts;

using MyFirstAspireApp.ApiService.Shared;

public record GetWeatherForecastCommand(int NumberOfDays) : ICommand<GetWeatherForecastResponse>;