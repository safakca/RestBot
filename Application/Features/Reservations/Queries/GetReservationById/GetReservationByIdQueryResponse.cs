using Domain.DTOs;

namespace Application.Features.Queries.Reservation.GetReservationById;

public class GetReservationByIdQueryResponse
{
    public ReservationDto? ReservationDto { get; set; }
    public bool Succeed { get; set; }
    public string Message { get; set; }
}