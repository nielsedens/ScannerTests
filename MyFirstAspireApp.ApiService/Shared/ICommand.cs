// ------------------------------------------------------------------------------
//  <copyright file="ICommand.cs" company="MY-LEX b.v.">
//      Copyright (c) MY-LEX b.v., The Netherlands. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------

namespace MyFirstAspireApp.ApiService.Shared;

using MediatR;

public interface ICommand<out TResponse> : IRequest<TResponse>;