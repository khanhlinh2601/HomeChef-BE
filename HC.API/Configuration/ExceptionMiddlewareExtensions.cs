using HC.Application.Common.Model;
using Microsoft.AspNetCore.Diagnostics;
using Newtonsoft.Json;
using System.Net;

namespace HC.API.Configuration
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, bool isDevelopmentEnvironment)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        Response<string> response;
                        if (!isDevelopmentEnvironment)
                        {
                            response = new Response<string>
                            {
                                Message = "Have error, please try again later!"
                            };
                        }
                        else
                        {
                            response = new Response<string>
                            {
                                Message = contextFeature.Error.Message
                            };
                        }

                        await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
                    }
                });
            });
        }
    }
}
