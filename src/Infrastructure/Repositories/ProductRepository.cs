using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _context.Products.Include(p => p.Category).ToListAsync();
    }

    public Task<Product?> GetByIdAsync(int id)
    {
        return _context.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
    }
    public async Task AddAsync(Product product)
    {
        await _context.Products.AddAsync(product);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}