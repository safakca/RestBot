using Domain.DTOs;

namespace Application.Features.Queries.Reservation.GetReservation;

public class GetReservationQueryResponse
{
    public IQueryable<ReservationDto>? ReservationDto { get; set; }
    public bool Succeed { get; set; }
    public string Message { get; set; }
}