using Application.Features.Reservations.Commands.CreateReservation;
using AutoMapper;
using Domain.DTOs;
using Domain.Entities;

namespace Application.Features.Reservations.Mappings;
public class ReservationMappingProfile : Profile
{
    public ReservationMappingProfile()
    {
        CreateMap<CreateReservationCommandRequest, Reservation>();
        CreateMap<Reservation, ReservationDto>().ReverseMap();

    }
}