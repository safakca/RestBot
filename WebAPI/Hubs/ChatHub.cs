using Application.Abstractions;
using Microsoft.AspNetCore.SignalR;

namespace WebAPI.Hubs;

public class ChatHub : Hub
{
    private readonly IAIChatService _aiChatService;

    public ChatHub(IAIChatService aiChatService)
    {
        _aiChatService = aiChatService;
    }

    public async Task SendMessage(string user, string message)
    {
        var aiResponse = await _aiChatService.GetAIResponseAsync(message);
        await Clients.Caller.SendAsync("ReceiveMessage", "AI", aiResponse);
    }
}