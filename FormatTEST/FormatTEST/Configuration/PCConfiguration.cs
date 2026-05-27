using FormatTEST.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FormatTEST.Configuration;

public class PCConfiguration : IEntityTypeConfiguration<PC>
{
    public void Configure(EntityTypeBuilder<PC> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
        builder.Property(p => p.CreatedAt).HasColumnType("datetime");
        
        builder.ToTable("PCs");

        builder.HasData(new List<PC>()
        {
            new PC { Id = 1, Name = "Gaming B", Weight = 12.5f, Warranty = 36, CreatedAt = DateTime.Parse("2026-05-08T09:00:00"), Stock = 5 },
            new PC { Id = 2, Name = "Mini Pro", Weight = 4.2f, Warranty = 24, CreatedAt = DateTime.Parse("2026-04-15T13:30:00"), Stock = 12 },
            new PC { Id = 3, Name = "Budget Build", Weight = 8.0f, Warranty = 12, CreatedAt = DateTime.Parse("2026-05-27T12:00:00"), Stock = 2 }         });
    }
}
