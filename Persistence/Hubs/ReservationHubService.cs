using System.Threading.Tasks;
using Application.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace Persistence.Hubs;
public class ReservationHubService<T> : IReservationHubService<T> where T : Hub
{
    private readonly IHubContext<T> _hubContext;

    public ReservationHubService(IHubContext<T> hubContext)
    {
        _hubContext = hubContext;
    }

    public async Task SendMessageAsync(string method, object message)
    {
        await _hubContext.Clients.All.SendAsync(method, message);
    }
}