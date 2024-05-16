using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Polly;
using Polly.Extensions.Http;
using Polly.Retry;
using Senac.Mvc.Scaffolding.Web.Extensions;
using Senac.Mvc.Scaffolding.Web.Services;
using Senac.Mvc.Scaffolding.Web.Services.Handlers;
using Senac.Mvc.Scaffolding.Core.Extensions;

namespace Senac.Mvc.Scaffolding.Web.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddSingleton<IValidationAttributeAdapterProvider,
                CpfValidationAttributeAdapterProvider>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUserService, UserService>();

            #region HttpServices
            services.AddTransient<HttpClientAuthorizationDelegatingHandler>();

            services.AddHttpClient<IAuthService, AuthenticationService>()
                .AddPolicyHandler(PollyExtensions.WaitAndTry())
                .AllowSelfSignedCertificate()
                .AddTransientHttpErrorPolicy(
                    p => p.CircuitBreakerAsync(5, TimeSpan.FromSeconds(30)));

            

            #endregion
        }
    }

    public static class PollyExtensions
    {
        public static AsyncRetryPolicy<HttpResponseMessage> WaitAndTry()
        {
            var retry = HttpPolicyExtensions
                .HandleTransientHttpError()
                .WaitAndRetryAsync(new[]
                {
                    TimeSpan.FromSeconds(1),
                    TimeSpan.FromSeconds(5),
                    TimeSpan.FromSeconds(10),
                }, (outcome, timespan, retryCount, context) =>
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"Tentando pela {retryCount} vez!");
                    Console.ForegroundColor = ConsoleColor.White;
                });

            return retry;
        }
    }
}
