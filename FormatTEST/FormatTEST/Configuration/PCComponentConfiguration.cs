using FormatTEST.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FormatTEST.Configuration;

public class PCComponentConfiguration : IEntityTypeConfiguration<PCComponent>
{
    public void Configure(EntityTypeBuilder<PCComponent> builder)
    {
        // Composite Primary Key
        builder.HasKey(pcc => new { pcc.PCId, pcc.ComponentCode });
        builder.Property(pcc => pcc.ComponentCode).HasMaxLength(10);

        builder.ToTable("PCComponents");

        // Explicit Relationships Mapping
        builder.HasOne(pcc => pcc.PC)
            .WithMany(p => p.PCComponents)
            .HasForeignKey(pcc => pcc.PCId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(pcc => pcc.Component)
            .WithMany(c => c.PCComponents)
            .HasForeignKey(pcc => pcc.ComponentCode)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasData(new List<PCComponent>()
        {
            new PCComponent { PCId = 1, ComponentCode = "CPU001", Amount = 1 },
            new PCComponent { PCId = 1, ComponentCode = "GPU001", Amount = 1 },
            new PCComponent { PCId = 1, ComponentCode = "RAM001", Amount = 2 }
        });
    }
}