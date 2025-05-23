using Application.Repositories;
using Application.Repositories.Reservations;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories.Reservations;
public class ReservationReadRepository : ReadRepository<Reservation>, IReservationReadRepository
{
    public ReservationReadRepository(Context context) : base(context)
    {
    }
}