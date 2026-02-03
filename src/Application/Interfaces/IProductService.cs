using Application.DTOs;
namespace Application.Interfaces;

public interface IProductService
{
    public Task<IEnumerable<ProductDto>> GetAllAsync();
    public Task<ProductDto?> GetByIdAsync(int id);
    public Task<int> CreateAsync(CreateProductDto productDto);
}