using Domain.Common;

namespace Domain.Entities;

public class Product : BaseEntity
{

    protected Product() { }

    public Product(string name, string description, decimal price, int stock, int categoryId)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
        if (price < 0) throw new ArgumentOutOfRangeException(nameof(price), "Price cannot be negative.");
        if (stock < 0) throw new ArgumentOutOfRangeException(nameof(stock), "Initial stock cannot be negative.");

        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
        CategoryId = categoryId;
    }
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public decimal Price { get; private set; }
    public int Stock { get; private set; }

    public int CategoryId { get; private set; }

    public virtual Category? Category { get; private set; }

    public byte[] RowVersion { get; set; }

    public void UpdateStock(int quantity)
    {
        var newStock = Stock + quantity;
        if (newStock < 0)
        {
            throw new InvalidOperationException($"Insufficient stock for product '{Name}'. Available: {Stock}, Requested: {Math.Abs(quantity)}");
        }

        Stock = newStock;
    }

    public void ChangePrice(decimal newPrice)
    {
        if (newPrice < 0) throw new ArgumentOutOfRangeException(nameof(newPrice), "Price cannot be negative."); Price = newPrice;
    }

}