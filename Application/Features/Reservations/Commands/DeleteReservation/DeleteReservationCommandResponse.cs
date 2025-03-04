namespace Application.Features.Commands.Reservations.DeleteReservation;

public class DeleteReservationCommandResponse
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public DeleteReservationCommandResponse(bool success, string message)
    {
        Success = success;
        Message = message;
    }
}