using Application.Features.Commands.Reservations.DeleteReservation;
using Application.Features.Commands.Reservations.UpdateReservation;
using Application.Features.Queries.Reservation.GetReservation;
using Application.Features.Queries.Reservation.GetReservationById;
using Application.Features.Reservations.Commands.CreateReservation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReservationController : ControllerBase
{
    private readonly IMediator _mediator;

    public ReservationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> CreateReservation(CreateReservationCommandRequest command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> UpdateReservation(UpdateReservationCommandRequest command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteReservation(int id)
    {
        var command = new DeleteReservationCommandRequest() { Id = id };
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetReservations([FromQuery] GetReservationQueryRequest request)
    {
        var response = await _mediator.Send(request: request);
        return Ok(response);
    }

    [HttpGet("[action]")] 
    public async Task<IActionResult> GetReservationById(int id)
    {
        var query = new GetReservationByIdQueryRequest { Id = id };
        var response = await _mediator.Send(query);
        return Ok(response);
    }
}