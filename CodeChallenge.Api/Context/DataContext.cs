using CodeChallenge.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeChallenge.Api.Context;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; init; }
    public DbSet<Order> Orders { get; init; }
    public DbSet<Customer> Customers { get; init; }
}