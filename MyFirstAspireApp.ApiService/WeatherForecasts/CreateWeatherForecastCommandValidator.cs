// ------------------------------------------------------------------------------
//  <copyright file="CreateWeatherForecastCommandValidator.cs" company="MY-LEX b.v.">
//      Copyright (c) MY-LEX b.v., The Netherlands. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------

namespace MyFirstAspireApp.ApiService.WeatherForecasts;

using FluentValidation;

public class CreateWeatherForecastCommandValidator : AbstractValidator<CreateWeatherForecastCommand>
{
    ////public WeatherForecastCreateCommandValidator()
    ////{
    ////    RuleFor(x => x.Forecast).NotNull();
    ////    RuleFor(x => x.Forecast.Id).NotNull().NotEmpty();
    ////    RuleFor(x => x.Forecast.Date).InclusiveBetween(DateOnly.FromDateTime(DateTime.Now), DateOnly.MaxValue);
    ////    RuleFor(x => x.Forecast.TemperatureC).InclusiveBetween(-273, int.MaxValue);

    ////}

    public CreateWeatherForecastCommandValidator(IValidator<WeatherForecast> validator)
    {
        RuleFor(x => x.Forecast).SetValidator(validator);
    }
}