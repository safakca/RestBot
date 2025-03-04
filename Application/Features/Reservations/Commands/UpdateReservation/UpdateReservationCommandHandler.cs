using Application.Abstractions;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Commands.Reservations.UpdateReservation;

public class UpdateReservationCommandHandler : IRequestHandler<UpdateReservationCommandRequest, UpdateReservationCommandResponse>
{
    private readonly IUnitOfWork _uOw;
    private readonly IMapper _mapper;

    public UpdateReservationCommandHandler(IUnitOfWork uOw, IMapper mapper)
    {
        _uOw = uOw;
        _mapper = mapper;
    }

    public async Task<UpdateReservationCommandResponse> Handle(UpdateReservationCommandRequest request, CancellationToken cancellationToken)
    {
        Reservation reservation = await _uOw.ReadRepository<Reservation>().GetWhere(x => x.Id == request.Reservation.Id).FirstOrDefaultAsync();

        if (reservation == null)
            return new UpdateReservationCommandResponse(succeed: false, message: "Reservation not found");

        _mapper.Map(request.Reservation, reservation);

        IWriteRepository<Reservation> repository = _uOw.WriteRepository<Reservation>();
        bool result = repository.Update(reservation);

        if (result)
        {
            await _uOw.SaveChangesAsync();
            return new UpdateReservationCommandResponse(succeed: true, message: "Reservation updated successfully");
        }

        return new UpdateReservationCommandResponse(succeed: false, message: "Failed to update reservation");
    }
}