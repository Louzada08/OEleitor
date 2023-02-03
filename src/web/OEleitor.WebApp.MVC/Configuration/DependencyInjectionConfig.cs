using Microsoft.AspNetCore.Mvc.DataAnnotations;
using OEleitor.Infra.CrossCurtting.Identidade;
using OEleitor.WebApp.MVC.Services;
using OEleitor.WebApp.MVC.Services.Handlers;
using Polly;
using Polly.Extensions.Http;
using Polly.Retry;

namespace OEleitor.WebApp.MVC.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddSingleton<IValidationAttributeAdapterProvider, EmailValidationAttributeAdapterProvider>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAspNetUser, AspNetUser>();

            #region HttpServices
            services.AddTransient<HttpClientAuthorizationDelegatingHandler>();

            services.AddHttpClient<IAutenticacaoService, AutenticacaoService>()
                .AddPolicyHandler(PollyExtensions.EsperarTentar())
                .AddTransientHttpErrorPolicy(
                    p => p.CircuitBreakerAsync(3, TimeSpan.FromSeconds(30)));

            services.AddHttpClient<IBairroService, BairroService>()
                .AddPolicyHandler(PollyExtensions.EsperarTentar())
                .AddTransientHttpErrorPolicy(
                    p => p.CircuitBreakerAsync(3, TimeSpan.FromSeconds(30)));

            //services.AddHttpClient<IPatrimonioService, PatrimonioService>()
            //  .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>()
            //          .AddPolicyHandler(PollyExtensions.EsperarTentar())
            //          .AddTransientHttpErrorPolicy(
            //              p => p.CircuitBreakerAsync(3, TimeSpan.FromSeconds(30)));

            //services.AddHttpClient<ITermoTransferenciaService, TermoTransferenciaService>()
            //    .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>()
            //    .AddPolicyHandler(PollyExtensions.EsperarTentar())
            //    .AddTransientHttpErrorPolicy(
            //        p => p.CircuitBreakerAsync(3, TimeSpan.FromSeconds(30)));

            //services.AddHttpClient<IUsuarioService, UsuarioService>()
            //    .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>()
            //    .AddPolicyHandler(PollyExtensions.EsperarTentar())
            //    .AddTransientHttpErrorPolicy(
            //        p => p.CircuitBreakerAsync(3, TimeSpan.FromSeconds(30)));

            //services.AddHttpClient<IUnidadeService, UnidadeService>()
            //    .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>()
            //    .AddPolicyHandler(PollyExtensions.EsperarTentar())
            //    .AddTransientHttpErrorPolicy(
            //        p => p.CircuitBreakerAsync(3, TimeSpan.FromSeconds(30)));
            #endregion
        }
    }

    public class PollyExtensions
    {
        public static AsyncRetryPolicy<HttpResponseMessage> EsperarTentar()
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