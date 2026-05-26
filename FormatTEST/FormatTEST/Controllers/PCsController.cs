using FormatTEST.Services;
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
        
    }
    
    
}