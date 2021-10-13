using ModularRestaurant.Shared.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ModularRestaurant.Bootstrapper.ExceptionHandling
{
    internal static class ExceptionMapping
    {
        internal static ErrorResponse ToErrorResponse(this Exception e)
        {
            return e switch
            {
                BusinessRuleException businessRuleException => new ErrorResponse(new ErrorMessage(businessRuleException.Message), HttpStatusCode.Conflict),
                _ => new ErrorResponse(new ErrorMessage("Internal server error."), HttpStatusCode.InternalServerError)
            };
        }
    }
}
