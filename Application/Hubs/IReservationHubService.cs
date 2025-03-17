namespace Application.Hubs;

using System.Threading.Tasks;

public interface IReservationHubService<T>
{
    Task SendMessageAsync(string method, object message);
}