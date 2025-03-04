using MediatR;

namespace Application.Features.Commands.Reservations.DeleteReservation;

public class DeleteReservationCommandRequest : IRequest<DeleteReservationCommandResponse>
{
    public int Id { get; set; }
}