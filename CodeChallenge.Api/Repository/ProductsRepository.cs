using CodeChallenge.Api.Context;
using CodeChallenge.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeChallenge.Api.Repository;

public class ProductsRepository(DataContext dataContext) : IProductsRepository
{
    /// <summary>
    /// This method fetch all product record from database 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Product[]> GetAllAsync(CancellationToken cancellationToken)
    {
        return await dataContext.Products.AsNoTracking().ToArrayAsync(cancellationToken);
    }

    /// <summary>
    /// This method get a single record by Id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await dataContext.Products.FindAsync(new object?[] { id }, cancellationToken: cancellationToken);
    }

    /// <summary>
    /// This method creates a new record to the database
    /// </summary>
    /// <param name="product"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<bool> AddAsync(Product product, CancellationToken cancellationToken)
    {
        await dataContext.Products.AddAsync(product, cancellationToken);
        return await SaveAllAsync(cancellationToken);
    }

    /// <summary>
    /// This method updates the full entity in database
    /// </summary>
    /// <param name="product"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<bool> UpdateAsync(Product product, CancellationToken cancellationToken)
    {
        dataContext.Products.Update(product);
        return await SaveAllAsync(cancellationToken);
    }

    /// <summary>
    /// This method remove a record from database
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        // I'm not taking account all validations and performance issues
        if (await GetByIdAsync(id, cancellationToken) is not { } product) return false;

        dataContext.Products.Remove(product);
        return await SaveAllAsync(cancellationToken);
    }

    /// <summary>
    /// This method saves all changes made in the unit of work
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    private async Task<bool> SaveAllAsync(CancellationToken cancellationToken) => await dataContext.SaveChangesAsync(cancellationToken) > 0;
}