using CaminhadasAPI.Data;
using CaminhadasAPI.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CaminhadasAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RegionController : ControllerBase{
    private readonly AppDbContext _ctx;

    public RegionController(AppDbContext ctx) {
        _ctx = ctx;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetAllRegions() {
        var regions = _ctx.Regions.ToList();
        return Ok(regions);
    }

    [HttpGet]
    [Route("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetRegionsById([FromRoute] Guid id) {
        if (id == null) {
            return NotFound("Id passed was null");
        }
        var region = _ctx.Regions.FirstOrDefault(r => r.Id == id);
        if (region == null) {
            return NotFound("Region not found");
        }

        return Ok(region);
    }
}