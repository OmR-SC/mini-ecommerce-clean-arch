using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistance.Configurations;

public class OrderConfigurations : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(o => o.Status)
            .HasConversion(
                v => v.ToString(),
                v => Enum.Parse<OrderStatus>(v)
            );

        builder.Ignore(o => o.TotalAmount);

        builder.HasMany(o => o.OrderItems)
            .WithOne(o => o.Order)
            .HasForeignKey(o => o.OrderId);

        builder.HasMany(o => o.OrderItems)
            .WithOne(o => o.Order)
            .OnDelete(DeleteBehavior.Cascade);

    }
}