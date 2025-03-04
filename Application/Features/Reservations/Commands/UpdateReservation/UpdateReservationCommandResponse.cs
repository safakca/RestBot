namespace Application.Features.Commands.Reservations.UpdateReservation;

public class UpdateReservationCommandResponse
{
    public bool Succeed { get; set; }
    public string Message { get; set; }
    
    public UpdateReservationCommandResponse(bool succeed, string message)
    {
        Succeed = succeed;
        Message = message;
    }
}