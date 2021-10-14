using System.Net;

namespace ModularRestaurant.Shared.Api
{
    public record ErrorResponse(ErrorMessage Error, HttpStatusCode StatusCode);
}
