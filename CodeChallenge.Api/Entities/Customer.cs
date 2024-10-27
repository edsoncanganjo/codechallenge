namespace CodeChallenge.Api.Entities;

public class Customer
{
    public Guid Id { get; set; }
    public required string Name { get; set; }

    public ICollection<Order>? Orders { get; } = [];
}