using Domain.Common;

namespace Domain.Entities;

public class Reservation : BaseEntity
{
    public required string CustomerName { get; set; }
    public DateTime ReservationDate { get; set; }
}