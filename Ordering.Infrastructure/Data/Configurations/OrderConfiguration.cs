using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Domain.Enums;
using Ordering.Domain.Models;
using Ordering.Domain.ValueObjects;

namespace Ordering.Infrastructure.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasConversion(
                            orderId => orderId.Value,
                            dbId => OrderId.Of(dbId));

            builder.HasOne<Customer>()
                .WithMany()
                .HasForeignKey(x => x.CustomerId)
                .IsRequired();

            builder.HasMany(x => x.OrderItems)
                .WithOne()
                .HasForeignKey(x => x.OrderId);

            builder.ComplexProperty(
                x => x.OrderName, nameBuilder =>
                {
                    nameBuilder.Property(n => n.Value)
                        .HasColumnName(nameof(Order.OrderName))
                        .HasMaxLength(100)
                        .IsRequired();
                });

            builder.ComplexProperty(
                x => x.ShippingAddress, adressBuilder =>
                {
                    adressBuilder.Property(a => a.FirstName)
                        .HasMaxLength(50)
                        .IsRequired();

                    adressBuilder.Property(a => a.LastName)
                        .HasMaxLength(50)
                        .IsRequired();

                    adressBuilder.Property(a => a.EmailAddress)
                        .HasMaxLength(50);

                    adressBuilder.Property(a => a.AddressLine)
                        .HasMaxLength(180)
                        .IsRequired();

                    adressBuilder.Property(a => a.Country)
                        .HasMaxLength(50);

                    adressBuilder.Property(a => a.State)
                        .HasMaxLength(50);

                    adressBuilder.Property(a => a.ZipCode)
                        .HasMaxLength(5)
                        .IsRequired();
                });

            builder.ComplexProperty(
                x => x.Payment, paymentBuilder =>
                {
                    paymentBuilder.Property(a => a.CardName)
                        .HasMaxLength(50);

                    paymentBuilder.Property(a => a.CardNumber)
                        .HasMaxLength(24)
                        .IsRequired();

                    paymentBuilder.Property(a => a.Expiration)
                        .HasMaxLength(10);

                    paymentBuilder.Property(a => a.CVV)
                        .HasMaxLength(3);

                    paymentBuilder.Property(a => a.PaymentMethod);
                });

            builder.Property(x => x.Status)
                .HasDefaultValue(OrderStatus.Draft)
                .HasConversion(
                    x => x.ToString(),
                    dbStatus => (OrderStatus)Enum.Parse(typeof(OrderStatus), dbStatus));
        }
    }
}
