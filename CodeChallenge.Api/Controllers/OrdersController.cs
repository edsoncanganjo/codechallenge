using CodeChallenge.Api.Context;
using CodeChallenge.Api.Contracts;
using CodeChallenge.Api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeChallenge.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class OrdersController(DataContext dataContext) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var result = await dataContext.Orders.AsNoTracking().ToArrayAsync(cancellationToken: cancellationToken);

        return Ok(result);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        if (await dataContext.Orders.FindAsync(id) is not { } order) return NotFound();

        return Ok(order);
    }
    
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] OrderContract request, CancellationToken cancellationToken)
    {
        Order order = new()
        {
            CustomerId = request.CustomerId,
            TotalPrice = request.TotalPrice
        };

        var result = await dataContext.Orders.AddAsync(order, cancellationToken);
        await dataContext.SaveChangesAsync(cancellationToken);

        return CreatedAtAction(nameof(Get), new{id = order.Id}, order);
    }
}