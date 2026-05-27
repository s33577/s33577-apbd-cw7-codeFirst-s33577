using FormatTEST.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FormatTEST.Configuration;

public class ComponentConfiguration : IEntityTypeConfiguration<Component>
{
    public void Configure(EntityTypeBuilder<Component> builder)
    {
        builder.HasKey(c => c.Code);
        builder.Property(c => c.Code).HasMaxLength(10);
        builder.Property(c => c.Name).IsRequired().HasMaxLength(300);
        builder.Property(c => c.Description).IsRequired(); // Maps to nvarchar(max)

        builder.ToTable("Components");

        builder.HasData(new List<Component>()
        {
            new Component { Code = "CPU001", Name = "Ryzen 7", Description = "gaming processor", ComponentManufacturersId = 1, ComponentTypesId = 1 },
            new Component { Code = "GPU001", Name = "RTX 4080", Description = "gaming graphics card", ComponentManufacturersId = 2, ComponentTypesId = 2 },
            new Component { Code = "RAM001", Name = "Corsair", Description = "DDR5 RAM", ComponentManufacturersId = 3, ComponentTypesId = 3 }
        });
    }
}