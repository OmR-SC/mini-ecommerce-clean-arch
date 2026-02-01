using Domain.Common;

namespace Domain.Entities;

public class OrderItem : BaseEntity
{

    protected OrderItem() { }

    internal OrderItem(int productId, int quantity, decimal unitPrice)
    {
        if (quantity <= 0) throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be greater than zero.");
        if (unitPrice < 0) throw new ArgumentOutOfRangeException(nameof(unitPrice), "Unit price cannot be negative.");

        ProductId = productId;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }

    public int OrderId { get; private set; }
    public int ProductId { get; private set; }
    public int Quantity { get; private set; }
    public decimal UnitPrice { get; private set; }

    public Product? Product { get; private set; }
    public virtual Order? Order { get; private set; }

}