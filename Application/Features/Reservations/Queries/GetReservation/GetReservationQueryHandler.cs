using Application.Abstractions;
using AutoMapper;
using Domain.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Queries.Reservation.GetReservation;

public class GetReservationQueryHandler : IRequestHandler<GetReservationQueryRequest, GetReservationQueryResponse>
{
    private readonly IUnitOfWork _uOw;
    private readonly IMapper _mapper;

    public GetReservationQueryHandler(IUnitOfWork uOw, IMapper mapper)
    {
        _uOw = uOw ?? throw new ArgumentNullException(nameof(uOw));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<GetReservationQueryResponse> Handle(GetReservationQueryRequest request, CancellationToken cancellationToken)
    {
        var reservationList = await _uOw.ReadRepository<Domain.Entities.Reservation>()
            .GetAll()
            .ToListAsync(cancellationToken); // Asynchronously fetch the data

        if (!reservationList.Any())  // Check if the list is empty
        {
            return new GetReservationQueryResponse
            {
                ReservationDto = null,
                Succeed = false,
                Message = "Reservations not found."
            };
        }

        var reservationDtos = _mapper.Map<List<ReservationDto>>(reservationList); // Map the list to DTOs

        return new GetReservationQueryResponse
        {
            ReservationDto = reservationDtos.AsQueryable(), // Convert the list to IQueryable
            Succeed = true,
            Message = "Reservations listed successfully."
        };
    }
}