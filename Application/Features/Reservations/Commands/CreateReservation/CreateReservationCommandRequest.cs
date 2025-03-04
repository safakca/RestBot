using MediatR;

namespace Application.Features.Reservations.Commands.CreateReservation;

public class CreateReservationCommandRequest : IRequest<CreateReservationCommandResponse>
{
    public string CustomerName { get; set; } = null!;
    public DateTime ReservationDate { get; set; }
}
