namespace Application.Features.Reservations.Commands.CreateReservation;

public class CreateReservationCommandResponse
{
    public bool Succeed { get; set; }
    public string Message { get; set; }

    public CreateReservationCommandResponse(bool succeed, string message)
    {
        Succeed = succeed;
        Message = message;
    }
}