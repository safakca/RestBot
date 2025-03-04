using Application.Abstractions;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Reservations.Commands.CreateReservation;

public class
    CreateReservationCommandHandler : IRequestHandler<CreateReservationCommandRequest, CreateReservationCommandResponse>
{
    private readonly IUnitOfWork _uOw;
    private readonly IMapper _mapper;

    public CreateReservationCommandHandler(IUnitOfWork uOw, IMapper mapper)
    {
        _uOw = uOw ?? throw new ArgumentNullException(nameof(uOw));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<CreateReservationCommandResponse> Handle(CreateReservationCommandRequest request,
        CancellationToken cancellationToken)
    {
        Reservation reservation = _mapper.Map<Reservation>(request);

        IWriteRepository<Reservation> repository = _uOw.WriteRepository<Reservation>();
        bool result = await repository.AddAsync(reservation);

        if (result)
        {
            await _uOw.SaveChangesAsync();
            return new CreateReservationCommandResponse(succeed: true, message: "Reservation created successfully");
        }

        return new CreateReservationCommandResponse(succeed: false, message: "Failed to create reservation");
    }
}