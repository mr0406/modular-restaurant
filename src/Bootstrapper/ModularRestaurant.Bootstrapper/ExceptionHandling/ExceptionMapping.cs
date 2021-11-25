using System;
using System.Net;
using Microsoft.EntityFrameworkCore;
using ModularRestaurant.Shared.Api;
using ModularRestaurant.Shared.Domain.Exceptions;

namespace ModularRestaurant.Bootstrapper.ExceptionHandling
{
    internal static class ExceptionMapping
    {
        internal static ErrorResponse ToErrorResponse(this Exception e)
        {
            return e switch
            {
                BusinessRuleException businessRuleException => new ErrorResponse(
                    new ErrorMessage(businessRuleException.Message), HttpStatusCode.Conflict),
                ObjectNotFoundException objectNotFoundException => new ErrorResponse(
                    new ErrorMessage(objectNotFoundException.Message), HttpStatusCode.NotFound),
                DbUpdateConcurrencyException _ => new ErrorResponse(
                    new ErrorMessage("Operation was not successful due to concurrency conflict."), HttpStatusCode.Conflict),
                _ => new ErrorResponse(new ErrorMessage("Internal server error."), HttpStatusCode.InternalServerError)
            };
        }
    }
}