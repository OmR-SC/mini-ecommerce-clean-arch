using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Services;

public class ProductService : IProductService
{
    private readonly ApplicationDbContext _context;
    public ProductService(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<int> CreateAsync(CreateProductDto dto)
    {

        Console.WriteLine(dto.CategoryId);
        Console.WriteLine(dto.Price);

        var categoryExists = await _context.Categories.AnyAsync(c => c.Id == dto.CategoryId);

        if (!categoryExists)
        {
            throw new Exception($"Category with ID {dto.CategoryId} not found.");
        }

        var newProduct = new Product(
            dto.Name,
            dto.Description,
            dto.Price,
            dto.Stock,
            dto.CategoryId
        );

        Console.WriteLine(newProduct);

        _context.Products.Add(newProduct);
        await _context.SaveChangesAsync();

        return newProduct.Id;
    }
}