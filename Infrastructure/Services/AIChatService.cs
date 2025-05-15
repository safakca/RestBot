using Application.Abstractions;
using Application.Settings;
using Microsoft.SemanticKernel;
using Microsoft.Extensions.Options;

namespace Infrastructure.Services;

public class AIChatService : IAIChatService
{
    private readonly Kernel _kernel;

    public AIChatService(IOptions<OpenAISettings> options)
    {
        var settings = options.Value;

        _kernel = Kernel.CreateBuilder()
            .AddOpenAIChatCompletion(settings.Model, settings.ApiKey)
            .Build();
    }

    public async Task<string> GetAIResponseAsync(string message)
    {
        var result = await _kernel.InvokePromptAsync(message);
        return result.ToString();
    }
}