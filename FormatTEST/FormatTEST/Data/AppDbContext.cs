using FormatTEST.Entities;
using Microsoft.EntityFrameworkCore;

namespace FormatTEST.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    public DbSet<PC> PCs { get; set; }
    public DbSet<Component> Components { get; set; }
    public DbSet<ComponentType> ComponentTypes { get; set; }
    public DbSet<ComponentManuFacturer> ComponentManuFacturers { get; set; }
    public DbSet<PCComponent> PCComponents { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        modelBuilder.Entity<PCComponent>().HasKey(pc => new { pc.PCId, pc.ComponentCode });
        modelBuilder.Entity<ComponentType>().HasData(
            new ComponentType()
            {
                Id = 1,
                Abbreviation = "CPU",
                Name = "Processor",

            },
            new ComponentType()
            {
                Id = 3,
                Abbreviation = "RAM",
                Name = "RAM",
            },
            new ComponentType()
            {
                Id = 2,
                Abbreviation = "`GPU",
                Name = "GP card",
            });
            
            
        modelBuilder.Entity<ComponentManuFacturer>().HasData(
                new ComponentManuFacturer()
                {
                    Id = 1, 
                    Abbreviation = "AMD", 
                    FullName = "Advanced Micro Devices", 
                    FoundationDate = new DateTime(1969, 5, 1)
                },
                new ComponentManuFacturer()
                {
                    Id = 2, 
                    Abbreviation = "NV", 
                    FullName = "NVIDIA Corporation", 
                    FoundationDate = new DateTime(1993, 4, 5)
                },
                new ComponentManuFacturer() { Id = 3, Abbreviation = "COR", FullName = "Corsair Gaming Inc.", FoundationDate = new DateTime(1994, 1, 1) }
            );
        
        
        modelBuilder.Entity<Component>().HasData(
            new Component { Code = "CPU001", Name = "Ryzen 7", Description = "gaming processor", ComponentManufacturersId = 1, ComponentTypesId = 1 },
            new Component { Code = "GPU001", Name = "RTX 4080", Description = "gaming graphics card", ComponentManufacturersId = 2, ComponentTypesId = 2 },
            new Component { Code = "RAM001", Name = "Corsair", Description = "DDR5 RAM", ComponentManufacturersId = 3, ComponentTypesId = 3 }
        );
        
        modelBuilder.Entity<PC>().HasData(
            new PC { Id = 1, Name = "Gaming B", 
                Weight = 12.5f, 
                Warranty = 36, 
                CreatedAt = DateTime.Parse("2026-05-08T09:00:00"), 
                Stock = 5 },
            new PC { Id = 2, 
                Name = "Mini Pro",
                Weight = 4.2f, 
                Warranty = 24, 
                CreatedAt = DateTime.Parse("2026-04-15T13:30:00"), 
                Stock = 12 },
            new PC { Id = 3, 
                Name = "Budget Build", 
                Weight = 8.0f, 
                Warranty = 12, 
                CreatedAt = DateTime.Now, 
                Stock = 2 }
        );
        
        
        modelBuilder.Entity<PCComponent>().HasData(
            new PCComponent { PCId = 1, ComponentCode = "CPU001", Amount = 1 },
            new PCComponent { PCId = 1, ComponentCode = "GPU001", Amount = 1 },
            new PCComponent { PCId = 1, ComponentCode = "RAM001", Amount = 2 }
        );
    }
}