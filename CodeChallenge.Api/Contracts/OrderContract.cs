namespace CodeChallenge.Api.Contracts;

public record OrderContract(Guid CustomerId, decimal TotalPrice);