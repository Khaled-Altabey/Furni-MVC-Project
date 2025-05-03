using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Configurations
{
    public class OrderConfigurations : IEntityTypeConfiguration<Orders>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Orders> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(O => O.Id);
            builder.Property(O => O.Id).ValueGeneratedOnAdd();
            builder.Property(O => O.OrderDate).IsRequired();

            //Reltions 

            builder.HasMany(O => O.OrderProducts)
                   .WithOne(Op => Op.Orders)
                   .HasForeignKey(Op => Op.OrderId);
                
        }
    }
}
