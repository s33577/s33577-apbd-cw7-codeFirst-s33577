using FormatTEST.DTOs;
using FormatTEST.Entities;

namespace FormatTEST.Services;

public class DbService : IDbService
{
    private readonly string _connectionString;
    public DbService(IConfiguration config)
    {
        _connectionString = config.GetConnectionString("DefaultConnection") ?? string.Empty;
    }

    public Task<IEnumerable<PCResponseDTO>> GetAllPCsAsync()
    {
        return await _connectionString.PCs.Select(pc => new PCResponseDTO()
        {
           Id = pc.Id, 
           Name = pc.Name, 
           Weight = pc.Weight,
           Warranty = pc.Warranty,
           CreatedAt = pc.CreatedAt,
           Stock = pc.Stock 
        });
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
        _connectionString.Add(pc);
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

    public async Task<bool> DeletePCAsync(int id)
    {
        var pc = await _connectionString.PCs.FindAsync(id);
        if (pc == null) return false;

        _connectionString.Remove(pc);
        await _connectionString.SaveChangesAsync();
        return true;
    }
}