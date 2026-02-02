using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class Order : BaseEntity
{
    protected Order() { }

    public Order(int userId)
    {
        if (userId <= 0) throw new ArgumentException("Invalid User ID.", nameof(userId));
        UserId = userId;
        Status = OrderStatus.Pending;
        OrderDate = DateTime.UtcNow;
    }
    public int UserId { get; private set; }
    public DateTime OrderDate { get; private set; } = DateTime.UtcNow;
    public OrderStatus Status { get; private set; }

    public decimal TotalAmount => _orderItems.Sum(i => i.UnitPrice * i.Quantity);

    private readonly List<OrderItem> _orderItems = new List<OrderItem>();
    public virtual IReadOnlyCollection<OrderItem> OrderItems => _orderItems.AsReadOnly();

    public virtual User? User { get; private set; }

    public void AddItem(int productId, int quantity, decimal unitPrice)
    {
        if (Status != OrderStatus.Pending)
        {
            throw new InvalidOperationException("Cannot add items to an order that is not pending.");
        }
        var item = new OrderItem(productId, quantity, unitPrice);
        _orderItems.Add(item);
    }



}