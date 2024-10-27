using CodeChallenge.Api.Entities;

namespace CodeChallenge.Api.Repository;

public interface IProductsRepository
{
    /// <summary>
    /// This method fetch all product record from database 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Product[]> GetAllAsync(CancellationToken cancellationToken);

    /// <summary>
    /// This method get a single record by Id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    /// <summary>
    /// This method creates a new record to the database
    /// </summary>
    /// <param name="product"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<bool> AddAsync(Product product, CancellationToken cancellationToken);

    /// <summary>
    /// This method updates the full entity in database
    /// </summary>
    /// <param name="product"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<bool> UpdateAsync(Product product, CancellationToken cancellationToken);

    /// <summary>
    /// This method remove a record from database
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken);
}