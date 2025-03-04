using Application.Repositories;
using Application.Repositories.Reservations;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories.Reservations;

public class ReservationWriteRepository : WriteRepository<Reservation>, IReservationWriteRepository
{
    public ReservationWriteRepository(Context context) : base(context)
    {
    }
}