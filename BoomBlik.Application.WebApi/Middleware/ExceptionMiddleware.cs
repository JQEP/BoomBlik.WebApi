using System.Net;
using BoomBlik.Core.Domain.Exceptions;
using SmartOffice.Application.WebApi.Middleware;

namespace boomblik_api.Middleware;

public class ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IConfiguration configuration)
{
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await next(httpContext);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Something went wrong");
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        return exception switch
        {
            EntityNotFoundException e => HandleEntityNotFoundExceptionAsync(context, e),
            ArgumentException e => HandleArgumentExceptionAsync(context, e),
            _ => HandleDefaultExceptionAsync(context, exception)
        };
    }

    private Task HandleEntityNotFoundExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.StatusCode = (int)HttpStatusCode.NotFound;
        return context.Response.WriteAsync(new ErrorDetails
        {
            StatusCode = context.Response.StatusCode,
            Message = exception.Message
        }.ToString());
    }

    private Task HandleInvalidPagingModelExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        return context.Response.WriteAsync(new ErrorDetails
        {
            StatusCode = context.Response.StatusCode,
            Message = exception.Message
        }.ToString());
    }

    private Task HandleArgumentExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        return context.Response.WriteAsync(new ErrorDetails
        {
            StatusCode = context.Response.StatusCode,
            Message = configuration.GetValue<bool>("SendDetailedExceptions") ? exception.Message : "A given parameter was not valid."
        }.ToString());
    }

    private Task HandleDefaultExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        return context.Response.WriteAsync(new ErrorDetails
        {
            StatusCode = context.Response.StatusCode,
            Message = configuration.GetValue<bool>("SendDetailedExceptions") ? exception.Message : "Internal Server Error."
        }.ToString());
    }
}
