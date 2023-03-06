using eCommerce.Api.Configuration;
using eCommerce.Api.Middleware;
using NLog;
using NLog.Web;
using System.Net;

namespace eCommerce.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = LogManager.Setup().LoadConfigurationFromFile().GetCurrentClassLogger();
            logger.Debug("init main");
            try
            {
                var builder = WebApplication.CreateBuilder(args);

                builder.Services.AddCors(options =>
                {
                    options.AddPolicy("all", builder => builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod());
                });

                // NLog: Setup NLog for Dependency injection
                builder.Logging.ClearProviders();
                builder.Host.UseNLog();

                //Configure dependencies
                builder.Services.RegisterServices(builder.Configuration);

                if (!builder.Environment.IsDevelopment())
                {
                    if (int.TryParse(Environment.GetEnvironmentVariable("API_REDIRECT_PORT"), out int port))
                    {
                        builder.Services.AddHttpsRedirection(options =>
                        {
                            options.RedirectStatusCode = (int)HttpStatusCode.PermanentRedirect;
                            options.HttpsPort = port;
                        });
                    }
                }
                var app = builder.Build();

                app.UseMiddleware<ExceptionMiddleware>();

                // Configure the HTTP request pipeline.
                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }

                app.UseHttpsRedirection();
                app.UseCors("all");

                app.UseAuthentication();
                app.UseAuthorization();

                //app.MapControllers();

                app.MapControllerRoute(
                    name: "Managment",
                    pattern: "Managment/{controller=Home}/{action=Index}/{id?}");

                app.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                app.Run();
            }
            catch (Exception exception)
            {
                // NLog: catch setup errors
                logger.Error(exception, "Stopped program because of exception");
                throw;
            }
            finally
            {
                // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
                NLog.LogManager.Shutdown();
            }
        }
    }
}