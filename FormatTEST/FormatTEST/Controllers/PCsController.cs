using FormatTEST.Services;
using Kolokwium.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace FormatTEST.Controllers;

public class PCsController : ControllerBase
{
    private readonly IDbService _pcService;
    
    public PCsController(IDbService pcService)
    {
        _pcService = pcService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var res = await _pcService.GetAllPCsAsync();
        return Ok(res);
    }
    
    
    [Route("{id}/components")]
    [HttpGet]
    public async Task<IActionResult> GetPcComponentsById(int id)
    {
        try
        {
            // Note: Make sure to add this method to your IDbService
            var res = await _pcService.GetPcWithComponentsByIdAsync(id);
            return Ok(res);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    
}