using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Way2Commerce.Data.Models;

namespace Way2Commerce.Data.EntityConfigurations
{
    class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .HasKey(p => p.Id)
                .HasName("PK_Product_Id");

            builder
                .Property(p => p.Code)
                .HasColumnType("varchar(6)")
                .IsRequired(true);

            builder
                .Property(p => p.Name)
                .HasColumnType("varchar(100)")
                .IsRequired(true);

            builder
                .Property(p => p.Description)
                .HasColumnType("varchar(500)")
                .IsRequired(true);

            builder
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)")
                .IsRequired(true);

            builder
                .Property(p => p.CreatedAt)
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()");

            builder
                .HasOne(p => p.Category)
                .WithMany()
                .HasForeignKey(p => p.CategoryId);


        }
    }
}
