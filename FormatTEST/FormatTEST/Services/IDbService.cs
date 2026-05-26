using FormatTEST.DTOs;

namespace FormatTEST.Services;

public interface IDbService
{
    Task<IEnumerable<PCResponseDTO>> GetAllPCsAsync();
    Task<PCResponseDTO> CreatePCAsync(CreatePCRequestDTO request);
    Task UpdatePcAsync(int id, CreatePCRequestDTO request);
    Task DeletePCAsync(int id);
    Task<PCWithComponentsDTO> GetPcWithComponentsByIdAsync(int id);
    
    
}