using Application.Interfaces;
using Application.DTOs;
using Microsoft.AspNetCore.Mvc;
namespace Application.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpPost]
    public async Task<ActionResult> Create(CreateProductDto productDto)
    {

        try
        {
            Console.WriteLine(productDto.CategoryId);
            var productId = await _productService.CreateAsync(productDto);

            return CreatedAtAction(nameof(Create), new { id = productId }, new { id = productId });

        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }


    }

}