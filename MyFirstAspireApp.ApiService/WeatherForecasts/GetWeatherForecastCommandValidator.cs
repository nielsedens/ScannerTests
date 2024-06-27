// ------------------------------------------------------------------------------
//  <copyright file="GetWeatherForecastCommandValidator.cs" company="MY-LEX b.v.">
//      Copyright (c) MY-LEX b.v., The Netherlands. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------

using FluentValidation;

namespace MyFirstAspireApp.ApiService.WeatherForecasts;

public class GetWeatherForecastCommandValidator : AbstractValidator<GetWeatherForecastCommand>
{
    public GetWeatherForecastCommandValidator()
    {
        RuleFor(x => x.NumberOfDays).InclusiveBetween(1, 10);
    }
}