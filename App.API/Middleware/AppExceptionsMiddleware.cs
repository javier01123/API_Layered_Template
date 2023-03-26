using App.Application.Loggers.Text;
using App.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;

namespace App.API.Middleware
{
    public class AppExceptionsMiddleware
    {
        private readonly RequestDelegate _next;

        public AppExceptionsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, ILogger<TextFileLogger> logger)
        {
            var problemDetails = new ProblemDetails();

            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                switch (ex)
                {
                    case BadRequestEx e:
                        problemDetails.Status = (int)HttpStatusCode.BadRequest;
                        problemDetails.Title = "Validation error.";
                        break;
                    case NotFoundEx e:
                        problemDetails.Status = (int)HttpStatusCode.NotFound;
                        problemDetails.Title = "Not Found.";
                        break;
                    case NotAuthorizedEx e:
                        problemDetails.Status = (int)HttpStatusCode.Forbidden;
                        problemDetails.Title = "Permissions error.";
                        break;
                    case Exception e:
                        logger.LogError(ex, $"Source: {nameof(AppExceptionsMiddleware)}, Activity Id: {Activity.Current?.Id}");
                        problemDetails.Status = (int)HttpStatusCode.InternalServerError;
                        problemDetails.Title = "An error occured while processing your request.";
                        break;
                }

                problemDetails.Detail = ex.Message;

                problemDetails.Extensions["traceId"] = Activity.Current?.Id;
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = problemDetails.Status.Value;

                
                //serialize problem details
                if (context.RequestServices.GetService<IProblemDetailsService>() is { } problemdetailsService)
                {
                    await problemdetailsService.WriteAsync(new()
                    {
                        HttpContext = context,
                        ProblemDetails = problemDetails,
                    });
                }



            }
        }

    }
}
