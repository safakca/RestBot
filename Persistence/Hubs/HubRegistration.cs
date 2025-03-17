using Microsoft.AspNetCore.Builder;
using Persistence.Hubs;

namespace Persistence.Hubs;

public static class HubRegistration
{
    public static void MapHubs(this WebApplication webApplication)
    {
        webApplication.MapHub<ReservationHubService>("/reservation-hub");
    }
}