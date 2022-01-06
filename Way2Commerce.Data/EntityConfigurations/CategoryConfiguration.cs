using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Way2Commerce.Data.Models;

namespace Way2Commerce.Data.EntityConfigurations
{
    class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder
                .HasKey(c => c.Id)
                .HasName("PK_Category_Id");

            builder
                .Property(c => c.Name)
                .HasColumnType("varchar(100)")
                .IsRequired(true);

            builder
                .HasData(
                new Category
                {
                    Id = 1,
                    Name = "Cafés"
                },
                new Category
                {
                    Id = 2,
                    Name = "Equipamentos"
                },
                new Category
                {
                    Id = 3,
                    Name = "Kits"
                });
        }
    }
}
