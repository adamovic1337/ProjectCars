using FluentValidation;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Linq;
using System.Linq.Dynamic.Core.Exceptions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch.Exceptions;
using ProjectCars.Service.Exceptions;

namespace ProjectCars.API.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                context.Response.ContentType = "application/json";
                var statusCode = StatusCodes.Status500InternalServerError;
                object response = new
                {
                    title = "Internal Error",
                    errors = "Unexpected error occurred",
                    status = statusCode,
                    traceId = Activity.Current?.Id ?? context?.TraceIdentifier
                };
                

                switch (exception)
                {
                    case ValidationException validationException:
                        statusCode = StatusCodes.Status422UnprocessableEntity;
                        response = new
                        {
                            title = "Failed due to validation errors.",
                            errors = validationException.Errors.Select(x => new
                            {
                                x.PropertyName,
                                x.ErrorMessage
                            }),
                            status = statusCode,
                            traceId = Activity.Current?.Id ?? context?.TraceIdentifier
                        };
                        break;
                    case JsonPatchException patchException:
                        statusCode = StatusCodes.Status400BadRequest;
                        response = new
                        {
                            title = "Failed due to validation errors.",
                            errors = patchException.Message,
                            status = statusCode,
                            traceId = Activity.Current?.Id ?? context?.TraceIdentifier
                        };
                        break;
                    case EntityNotFoundException entityNotFound:
                        statusCode = StatusCodes.Status404NotFound;
                        response = new
                        {
                            title = "Not Found",
                            errors = entityNotFound.Message,
                            status = statusCode,
                            traceId = Activity.Current?.Id ?? context?.TraceIdentifier
                        };
                        break;
                    case ParseException parseException:
                        statusCode = StatusCodes.Status400BadRequest;
                        response = new
                        {
                            title = "Bad Request",
                            errors = parseException.Message,
                            status = statusCode,
                            traceId = Activity.Current?.Id ?? context?.TraceIdentifier
                        };
                        break;
                }

                context.Response.StatusCode = statusCode;

                await context.Response.WriteAsync(JsonConvert.SerializeObject(response));

                await Task.FromResult(context.Response);
            }
        }
    }
}