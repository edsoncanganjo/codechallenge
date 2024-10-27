namespace CodeChallenge.Api.Entities;

public class Product
{
    public Guid Id { get; init; }
    public required string Name { get; set; }
    public decimal Price { get; set; }
}