// ------------------------------------------------------------------------------
//  <copyright file="ICreateWeatherForecastCommandHandler.cs" company="MY-LEX b.v.">
//      Copyright (c) MY-LEX b.v., The Netherlands. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------

namespace MyFirstAspireApp.ApiService.WeatherForecasts;

using MediatR;

internal interface ICreateWeatherForecastCommandHandler : IRequestHandler<CreateWeatherForecastCommand, CreateWeatherForecastResponse>
{

}