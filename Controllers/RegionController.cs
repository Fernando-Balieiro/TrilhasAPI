using CaminhadasAPI.Data;
using CaminhadasAPI.Models.Domain;
using CaminhadasAPI.Models.DTOs;
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

        var regionsDto = new List<RegionDTO>();
        foreach (var region in regions) {
            regionsDto.Add(new RegionDTO() {
                Code = region.Code,
                Name = region.Name,
                ImageUrl = region.RegionImageUrl
            });
        }
        
        return Ok(regionsDto);
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

        var regionDto = new RegionDTO {
            Name = region.Name,
            Code = region.Code,
            ImageUrl = region.RegionImageUrl
        };

        return Ok(regionDto);
    }
}