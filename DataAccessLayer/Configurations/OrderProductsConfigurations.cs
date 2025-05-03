using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Configurations
{
    public class OrderProductsConfigurations : IEntityTypeConfiguration<OrderProducts>
    {
        public void Configure(EntityTypeBuilder<OrderProducts> builder)
        {
            builder.ToTable("OrderProducts");
            builder.HasKey(Op => new { Op.OrderId , Op.ProductId });
            builder.Property(Op=>Op.Amount).IsRequired();

            // Relations 

            builder.HasOne(Op => Op.Products)
                   .WithMany(P => P.OrderProducts)
                   .HasForeignKey(Op => Op.ProductId);

            builder.HasOne(op => op.Orders)
                   .WithMany(O => O.OrderProducts)
                   .HasForeignKey(op => op.OrderId);
        }
    }
}
