using FormatTEST.DTOs;
using FormatTEST.Entities;
using Kolokwium.Exceptions;
using FormatTEST.Data;
using Microsoft.EntityFrameworkCore;

namespace FormatTEST.Services;

public class DbService : IDbService
{
    private readonly AppDbContext _connectionString;
    public DbService(AppDbContext connectionString)
    {
        _connectionString = connectionString;
    }
    
    public async Task<IEnumerable<PCResponseDTO>> GetAllPCsAsync()
    {
        return await _connectionString.PCs.Select(pc => new PCResponseDTO()
        {
           Id = pc.Id, 
           Name = pc.Name, 
           Weight = pc.Weight,
           Warranty = pc.Warranty,
           CreatedAt = pc.CreatedAt,
           Stock = pc.Stock 
        }).ToListAsync();
    }

    public async Task<PCWithComponentsDTO> GetPcWithComponentsByIdAsync(int id)
    {
        var pc = await _connectionString.PCs
            .Where(p => p.Id == id)
            .Select(p => new PCWithComponentsDTO
            {
                Id = p.Id,
                Name = p.Name,
                Weight = p.Weight,
                Warranty = p.Warranty,
                CreatedAt = p.CreatedAt,
                Stock = p.Stock,
                Components = p.PCComponents.Select(pcc => new PCComponentDTO
                {
                    Amount = pcc.Amount,
                    Component = new ComponentDetailDTO
                    {
                        Code = pcc.Component.Code,
                        Name = pcc.Component.Name,
                        Description = pcc.Component.Description,
                        Manufacturer = new ManufacturerDTO
                        {
                            Id = pcc.Component.Manufacturers.Id,
                            Abbreviation = pcc.Component.Manufacturers.Abbreviation,
                            FullName = pcc.Component.Manufacturers.FullName,
                            FoundationDate = pcc.Component.Manufacturers.FoundationDate
                        },
                        Type = new ComponentTypeDTO
                        {
                            Id = pcc.Component.Type.Id,
                            Abbreviation = pcc.Component.Type.Abbreviation,
                            Name = pcc.Component.Type.Name
                        }
                    }
                }).ToList()
            }).FirstOrDefaultAsync();

        if (pc == null)
        {
            throw new NotFoundException($"PC with ID {id} not found.");
        }

        return pc;
    }

    public async Task<PCResponseDTO> CreatePCAsync(CreatePCRequestDTO request)
    {
        var pc = new PC
        {
            Name = request.Name,
            Weight = request.Weight,
            Warranty = request.Warranty,
            CreatedAt = request.CreatedAt,
            Stock = request.Stock
        };
        
        _connectionString.PCs.Add(pc);
        await _connectionString.SaveChangesAsync();
        
        return new PCResponseDTO()
        {
            Id = pc.Id,
            Name = pc.Name,
            Weight = pc.Weight,
            Warranty = pc.Warranty,
            CreatedAt = pc.CreatedAt,
            Stock = pc.Stock
        };
    }

    public async Task UpdatePcAsync(int id, CreatePCRequestDTO request)
    {
        var pc = await _connectionString.PCs.FirstOrDefaultAsync(p => p.Id == id);
        if (pc == null)
        {
            throw new NotFoundException($"PC with ID {id} not found.");
        }

        pc.Name = request.Name;
        pc.Weight = request.Weight;
        pc.Warranty = request.Warranty;
        pc.CreatedAt = request.CreatedAt;
        pc.Stock = request.Stock;

        await _connectionString.SaveChangesAsync();
    }

    public async Task DeletePCAsync(int id)
    {
        var pc = await _connectionString.PCs.FindAsync(id);
        if (pc == null) 
        {
            throw new NotFoundException($"PC with ID {id} not found.");
        }

        _connectionString.PCs.Remove(pc);
        await _connectionString.SaveChangesAsync();
    }
}