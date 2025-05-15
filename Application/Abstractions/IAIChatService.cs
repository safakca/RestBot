namespace Application.Abstractions;

public interface IAIChatService
{
    Task<string> GetAIResponseAsync(string userMessage);
}