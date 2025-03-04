namespace Domain.DTOs;

public class ReservationDto
{
    public int Id { get; set; }
    public string CustomerName { get; set; }
    public DateTime ReservationDate { get; set; }
}