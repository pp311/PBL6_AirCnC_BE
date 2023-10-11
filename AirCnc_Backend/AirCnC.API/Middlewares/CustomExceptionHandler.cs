using System.Net;
using System.Text.Json;
using AirCnC.Domain.Exceptions;
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
                    var message = $"{exception!.GetType().Name}: {exception.Message}";

                    response.StatusCode = exception switch
                    {
                        EntityNotFoundException => (int)HttpStatusCode.NotFound,
                        BadInputException => (int)HttpStatusCode.BadRequest,
                        _ => (int)HttpStatusCode.InternalServerError
                    };

                    var isDevelopment = env.IsDevelopment();
    
                    var pd = new ProblemDetails
                    {
                        Title = isDevelopment ? message : "An error occurred on the server.",
                        Status = response.StatusCode,
                        Detail = isDevelopment ? exception?.StackTrace : null
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