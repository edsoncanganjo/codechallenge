using CodeChallenge.Api.Contracts;
using CodeChallenge.Api.Entities;
using CodeChallenge.Api.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CodeChallenge.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController(IProductsRepository productsRepository) : ControllerBase
{
    // Process, and logic should not be in controller, I normally use to use CQRS pattern
    
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var result = await productsRepository.GetAllAsync(cancellationToken);

        return Ok(result);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        if (await productsRepository.GetByIdAsync(id, cancellationToken) is not { } product) return NotFound();

        return Ok(product);
    }
    
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] ProductInput request, CancellationToken cancellationToken)
    {
        Product product = new()
        {
            Name = request.Name,
            Price = request.Price
        };
        
        var result = await productsRepository.AddAsync(product, cancellationToken);

        return CreatedAtAction(nameof(Get), new{id = product.Id}, product);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] ProductInput request, CancellationToken cancellationToken)
    {
        if (await productsRepository.GetByIdAsync(id, cancellationToken) is not { } product) return NotFound();

        product.Name = request.Name;
        product.Price = request.Price;

        if (await productsRepository.UpdateAsync(product, cancellationToken)) return NoContent();

        return BadRequest();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        if (await productsRepository.GetByIdAsync(id, cancellationToken) is not { } product) return NotFound();
        
        await productsRepository.DeleteAsync(product.Id, cancellationToken);
        
        return NoContent();
    }
}