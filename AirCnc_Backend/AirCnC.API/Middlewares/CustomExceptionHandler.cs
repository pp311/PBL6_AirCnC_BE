using System.Net;
using System.Text.Json;
using AirCnC.Domain.Exceptions;
using AirCnC.Domain.Exceptions.Auth;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace AirCnC.API.Middlewares;

public static class CustomExceptionHandler
{
    public static void UseCustomExceptionHandler(this IApplicationBuilder app,
                                                     IWebHostEnvironment env)
        {
            app.UseExceptionHandler(exceptionHandlerApp =>
            {
                exceptionHandlerApp.Run(async context =>
                {
                    var response = context.Response;
                    response.ContentType = "application/json";
                    var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;

                    response.StatusCode = exception switch
                    {
                        EntityNotFoundException => (int)HttpStatusCode.NotFound,
                        BadInputException => (int)HttpStatusCode.BadRequest,
                        EntityAlreadyExistedException => (int)HttpStatusCode.Conflict,
                        RefreshTokenExpiredException => (int)HttpStatusCode.Unauthorized,
                        InvalidPasswordException => (int)HttpStatusCode.Unauthorized,
                        ForbiddenAccessException => (int)HttpStatusCode.Forbidden,
                        _ => (int)HttpStatusCode.InternalServerError
                    };

                    var isDevelopment = env.IsDevelopment();
    
                    var pd = new ProblemDetails
                    {
                        Title = exception!.GetType().Name,
                        Status = response.StatusCode,
                        Detail = isDevelopment ? $"{exception.Message} -{exception.StackTrace}" : exception.Message
                        // Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1"
                    };
    
                    // if (exception is ValidationException validationException)
                    //     pd.Extensions.Add("errors",
                    //         validationException.Errors.Select(x => new { x.PropertyName, x.ErrorMessage }));
    
                    pd.Extensions.Add("traceId", context.TraceIdentifier);
    
                    await response.WriteAsync(JsonSerializer.Serialize(pd));
                });
            });
        }
}