namespace FormatTEST.DTOs;

public class PCWithComponentsDTO : PCResponseDTO
{
    public IEnumerable<PCComponentDTO> Components { get; set; }
}