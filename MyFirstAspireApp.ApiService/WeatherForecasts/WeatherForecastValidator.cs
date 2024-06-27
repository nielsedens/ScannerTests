// ------------------------------------------------------------------------------
//  <copyright file="WeatherForecastValidator.cs" company="MY-LEX b.v.">
//      Copyright (c) MY-LEX b.v., The Netherlands. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------

using FluentValidation;

namespace MyFirstAspireApp.ApiService.WeatherForecasts;

public class WeatherForecastValidator : AbstractValidator<WeatherForecast>
{
    public WeatherForecastValidator()
    {
        RuleFor(x => x.Id).NotNull().NotEmpty();
        RuleFor(x => x.Date).InclusiveBetween(DateOnly.FromDateTime(DateTime.Now), DateOnly.MaxValue);
        RuleFor(x => x.TemperatureC).InclusiveBetween(-273, int.MaxValue);
    }
}