using CodeChallenge.Api.Context;
using CodeChallenge.Api.Contracts;
using CodeChallenge.Api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeChallenge.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomersController(DataContext dataContext) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var result = await dataContext.Customers.AsNoTracking().ToArrayAsync(cancellationToken: cancellationToken);

        return Ok(result);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        if (await dataContext.Customers.FindAsync(id) is not { } customer) return NotFound();

        return Ok(customer);
    }

    [HttpGet("{customerId:guid}/orders")]
    public async Task<IActionResult> GetOrders([FromRoute] Guid customerId, CancellationToken cancellationToken)
    {
        var result = await dataContext.Orders.AsNoTracking().Where(o => o.CustomerId == customerId).ToArrayAsync(cancellationToken: cancellationToken);

        return Ok(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CustomerContract request, CancellationToken cancellationToken)
    {
        Customer customer = new()
        {
            Name = request.Name
        };

        var result = await dataContext.Customers.AddAsync(customer, cancellationToken);
        await dataContext.SaveChangesAsync(cancellationToken);

        return CreatedAtAction(nameof(Get), new{id = customer.Id}, customer);
    }
}