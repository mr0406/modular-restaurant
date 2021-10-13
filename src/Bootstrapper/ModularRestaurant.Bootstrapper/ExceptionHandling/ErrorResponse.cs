using System.Net;

namespace ModularRestaurant.Bootstrapper.ExceptionHandling
{
    internal record ErrorResponse(ErrorMessage Error, HttpStatusCode StatusCode);
}
