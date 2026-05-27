using FormatTEST.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FormatTEST.Configuration;

public class ComponentManuFacturerConfiguration : IEntityTypeConfiguration<ComponentManuFacturer>
{
    public void Configure(EntityTypeBuilder<ComponentManuFacturer> builder)
    {
        builder.HasKey(cm => cm.Id);
        builder.Property(cm => cm.Abbreviation).IsRequired().HasMaxLength(30);
        builder.Property(cm => cm.FullName).IsRequired().HasMaxLength(300);
        builder.Property(cm => cm.FoundationDate).HasColumnType("date");
        
        builder.ToTable("ComponentManuFacturers");

        builder.HasData(new List<ComponentManuFacturer>()
        {
            new ComponentManuFacturer { Id = 1, Abbreviation = "AMD", FullName = "Advanced Micro Devices", FoundationDate = new DateTime(1969, 5, 1) },
            new ComponentManuFacturer { Id = 2, Abbreviation = "NV", FullName = "NVIDIA Corporation", FoundationDate = new DateTime(1993, 4, 5) },
            new ComponentManuFacturer { Id = 3, Abbreviation = "COR", FullName = "Corsair Gaming Inc.", FoundationDate = new DateTime(1994, 1, 1) }
        });
    }
}