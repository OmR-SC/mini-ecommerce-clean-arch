using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<ProductDto>> GetAllAsync()
    {
        var products = await _productRepository.GetAllAsync();

        return products.Select(p => new ProductDto
        {
            Id = p.Id,
            Name = p.Name,
            Description = p.Description,
            Price = p.Price,
            Stock = p.Stock,
            CategoryName = p.Category?.Name ?? "N/A"
        });
    }

    public async Task<ProductDto?> GetByIdAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);

        if (product == null) return null;
        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Stock = product.Stock,
            CategoryName = product.Category?.Name ?? "N/A"
        };
    }


    public async Task<int> CreateAsync(CreateProductDto dto)
    {

        //TODO: ICategoryRepository
        //var categoryExists = await _context.Categories.AnyAsync(c => c.Id == dto.CategoryId);

        // if (!categoryExists)
        // {
        //     throw new Exception($"Category with ID {dto.CategoryId} not found.");
        // }

        var newProduct = new Product(
            dto.Name,
            dto.Description,
            dto.Price,
            dto.Stock,
            dto.CategoryId
        );

        await _productRepository.AddAsync(newProduct);
        await _productRepository.SaveChangesAsync();

        return newProduct.Id;
    }
}