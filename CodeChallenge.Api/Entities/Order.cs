namespace CodeChallenge.Api.Entities;

public class Order
{
    public Guid Id { get; set; }
    public decimal TotalPrice { get; set; }
    
    public Guid CustomerId { get; set; }
    public virtual Customer Customer { get; set; } = null!;
}