namespace FormatTEST.DTOs;

public class ComponentDetailDTO
{
    public string Code { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ManufacturerDTO Manufacturer { get; set; }
    public ComponentTypeDTO Type { get; set; }
}