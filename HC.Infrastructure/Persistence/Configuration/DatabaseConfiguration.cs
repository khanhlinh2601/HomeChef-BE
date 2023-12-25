using HC.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HC.Infrastructure.Persistence.Configuration;

public class OrderConfig : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("orders");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Quantity).IsRequired();
        builder.Property(x => x.Price).IsRequired();
        builder.Property(x => x.Status).IsRequired();
    }
}

public class OrderVoucherConfig : IEntityTypeConfiguration<OrderVoucher>
{
    public void Configure(EntityTypeBuilder<OrderVoucher> builder)
    {
        builder.ToTable("order_vouchers");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.VoucherId).IsRequired();
        builder.Property(x => x.OrderId).IsRequired();
    }
}

public class AddressConfig : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("addresses");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Street).HasMaxLength(100);
        builder.Property(x => x.Ward).HasMaxLength(100);
        builder.Property(x => x.HouseNumber).HasMaxLength(1024);
        builder.Property(x => x.Description).HasMaxLength(1024);
    }
}

public class DistrictConfig : IEntityTypeConfiguration<District>
{
    public void Configure(EntityTypeBuilder<District> builder)
    {
        builder.ToTable("districts");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Name).HasMaxLength(100);
    }
}
