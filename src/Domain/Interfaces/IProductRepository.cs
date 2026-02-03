using Domain.Entities;

namespace Domain.Interfaces;

public interface IProductRepository
{
    public Task<Product?> GetByIdAsync(int id);
    public Task<IEnumerable<Product>> GetAllAsync();

    public Task AddAsync(Product product);

    public Task SaveChangesAsync();
    
}