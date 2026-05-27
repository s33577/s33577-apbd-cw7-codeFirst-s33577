using FormatTEST.DTOs;
using FormatTEST.Services;
using Kolokwium.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace FormatTEST.Controllers;


[Route("api/[controller]")]
[ApiController]
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
    
    
    [HttpGet("{id}/components")]
    public async Task<IActionResult> GetPcComponentsById([FromRoute] int id)
    {
        try
        {
            var res = await _pcService.GetPcWithComponentsByIdAsync(id);
            return Ok(res);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddPC(CreatePCRequestDTO request)
    {
        var res = await _pcService.CreatePCAsync(request);
        return Created($"api/pcs/{res.Id}", res);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePC([FromRoute] int id, CreatePCRequestDTO request)
    {
        try
        {
            await _pcService.UpdatePcAsync(id, request);
            return NoContent();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemovePC([FromRoute] int id)
    {
        try
        {
            await _pcService.DeletePCAsync(id);
            return NoContent();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        
    }
    
    
    
    
}