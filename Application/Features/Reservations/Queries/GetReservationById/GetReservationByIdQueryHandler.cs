using Application.Abstractions;
using AutoMapper;
using Domain.DTOs;
using MediatR;

namespace Application.Features.Queries.Reservation.GetReservationById;
//TODO: unitOfWork, mapper, logger, mediator should be injected here

public class GetReservationByIdQueryHandler : IRequestHandler<GetReservationByIdQueryRequest, GetReservationByIdQueryResponse>
{
    private readonly IUnitOfWork _uOw;
    private readonly IMapper _mapper;

    public GetReservationByIdQueryHandler(IUnitOfWork uOw, IMapper mapper)
    {
        _uOw = uOw;
        _mapper = mapper;
    }
    public async Task<GetReservationByIdQueryResponse> Handle(GetReservationByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var reservation = await _uOw.ReadRepository<Domain.Entities.Reservation>().GetByIdAsync(request.Id);
        var reservationDto = _mapper.Map<ReservationDto>(reservation);
        
        if(reservationDto == null)
        {
            return new GetReservationByIdQueryResponse()
            {
                ReservationDto = null,
                Succeed = false,
                Message = "Reservation not found."
            };
        }

        return new GetReservationByIdQueryResponse()
        {
            ReservationDto = reservationDto,
            Succeed = true,
            Message = "Reservation listed successfully."
        };
    }
}
