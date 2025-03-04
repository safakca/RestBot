using MediatR;

namespace Application.Features.Queries.Reservation.GetReservationById;

public class GetReservationByIdQueryRequest : IRequest<GetReservationByIdQueryResponse>
{
    public int Id { get; set; }
}