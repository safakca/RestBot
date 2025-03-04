using Application.Abstractions;
using Application.Repositories;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commands.Reservations.DeleteReservation;

public class DeleteReservationCommandHandler : IRequestHandler<DeleteReservationCommandRequest, DeleteReservationCommandResponse>
{
    private readonly IUnitOfWork _uOw;

    public DeleteReservationCommandHandler(IUnitOfWork uOw)
    {
        _uOw = uOw;
    }

    public async Task<DeleteReservationCommandResponse> Handle(DeleteReservationCommandRequest request, CancellationToken cancellationToken)
    {
        var reservation = _uOw.ReadRepository<Reservation>().GetWhere(x => x.Id == request.Id).FirstOrDefault();

        if (reservation == null)
            return new DeleteReservationCommandResponse(success: false, message: "Reservation not found");

        IWriteRepository<Reservation> repository = _uOw.WriteRepository<Reservation>();
        bool result = repository.Remove(reservation);

        if (result)
        {
            await _uOw.SaveChangesAsync();
            return new DeleteReservationCommandResponse(success: true, message: "Reservation deleted successfully");
        }

        return new DeleteReservationCommandResponse(success: false, message: "Failed to delete reservation");
    }
}