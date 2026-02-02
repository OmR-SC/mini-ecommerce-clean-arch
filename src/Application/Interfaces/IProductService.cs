using Application.DTOs;
namespace Application.Interfaces;

public interface IProductService
{

    public Task<int> CreateAsync(CreateProductDto productDto);
}