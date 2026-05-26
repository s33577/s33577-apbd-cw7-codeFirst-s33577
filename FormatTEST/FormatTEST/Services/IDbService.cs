using FormatTEST.DTOs;

namespace FormatTEST.Services;

public interface IDbService
{
    Task<IEnumerable<PCResponseDTO>> GetAllPCsAsync();
    Task<PCResponseDTO> CreatePCAsync(CreatePCRequestDTO request);
    Task<bool> DeletePCAsync(int id);
    
}