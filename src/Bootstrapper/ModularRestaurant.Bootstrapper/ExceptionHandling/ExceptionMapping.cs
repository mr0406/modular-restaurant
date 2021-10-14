using ModularRestaurant.Shared.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ModularRestaurant.Shared.Api;

namespace ModularRestaurant.Bootstrapper.ExceptionHandling
{
    internal static class ExceptionMapping
    {
        internal static ErrorResponse ToErrorResponse(this Exception e)
        {
            return e switch
            {
                BusinessRuleException businessRuleException => new ErrorResponse(new ErrorMessage(businessRuleException.Message), HttpStatusCode.Conflict),
                EntityNotFoundException entityNotFoundException => new ErrorResponse(new ErrorMessage(entityNotFoundException.Message), HttpStatusCode.NotFound),
                _ => new ErrorResponse(new ErrorMessage("Internal server error."), HttpStatusCode.InternalServerError)
            };
        }
    }
}
