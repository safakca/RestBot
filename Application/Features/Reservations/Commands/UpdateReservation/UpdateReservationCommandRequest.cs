
using Domain.DTOs;
using MediatR;

namespace Application.Features.Commands.Reservations.UpdateReservation;

public class UpdateReservationCommandRequest : IRequest<UpdateReservationCommandResponse>
{
   public ReservationDto Reservation { get; set; }
}