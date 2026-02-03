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

    // GET: api/products
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll()
    {
        var products = await _productService.GetAllAsync();

        return Ok(products);
    }

    // GET: api/products/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDto>> GetById(int id)
    {
        var product = await _productService.GetByIdAsync(id);

        if (product == null)
        {
            return NotFound(new { message = $"Product with ID {id} not found" });
        }

        return Ok(product);
    }

    // POST: api/products
    [HttpPost]
    public async Task<ActionResult> Create(CreateProductDto productDto)
    {

        try
        {
            var productId = await _productService.CreateAsync(productDto);

            return CreatedAtAction(nameof(Create), new { id = productId }, new { id = productId });

        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }


    }



}