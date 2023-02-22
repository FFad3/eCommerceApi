using eCommerce.Api.Models;
using eCommerceApp.Application.Exceptions;
using System.Net;

namespace eCommerce.Api.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            CustomProblemDetails problem = new();

            switch (ex)
            {
                case BadRequestException badRequest:
                    statusCode = HttpStatusCode.BadRequest;
                    problem = new CustomProblemDetails
                    {
                        Title = badRequest.Message,
                        Status = (int)statusCode,
                        Detail = badRequest.InnerException?.Message,
                        Type = nameof(BadRequestException),
                        Errors = badRequest.ValidationErrors
                    };
                    break;

                case NotFoundException notFound:
                    statusCode = HttpStatusCode.NotFound;
                    problem = new CustomProblemDetails
                    {
                        Title = notFound.Message,
                        Status = (int)statusCode,
                        Type = nameof(NotFoundException),
                        Detail = notFound.InnerException?.Message,
                    };
                    break;

                default:
                    problem = new CustomProblemDetails
                    {
                        Title = ex.Message,
                        Status = (int)statusCode,
                        Type = nameof(NotFoundException),
                        Detail = ex.StackTrace,
                    };
                    break;
            }

            httpContext.Response.StatusCode = (int)statusCode;
            await httpContext.Response.WriteAsJsonAsync(problem);
        }
    }
}