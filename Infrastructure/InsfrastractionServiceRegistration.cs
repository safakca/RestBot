using Application.Abstractions;
using Application.Settings;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Infrastructure;
public static class InsfrastractionServiceRegistration
{
    //TODO: Cross-Cutting Concerns - Logging, Caching, Exception Handling, etc. should be this later and injected here
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<OpenAISettings>(options => 
            configuration.GetSection(nameof(OpenAISettings)).Bind(options)
        );

        services.AddScoped<IAIChatService, AIChatService>();
    }

}