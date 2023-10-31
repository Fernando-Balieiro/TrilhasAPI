using CaminhadasAPI.Data;
using CaminhadasAPI.Models.Domain;
using CaminhadasAPI.Models.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
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
    public IActionResult GetRegionsById([FromRoute] Guid? id) {
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

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult CreateRegion([FromBody] AddRegionRequestDto? regionRequestDto) {
        if (regionRequestDto == null) {
            return BadRequest("Você deve passar uma região");
        }

        if (!ModelState.IsValid) {
            return BadRequest("Envie um model válido para o post");
        }
        var regionDomainModel = new Region {
            Code = regionRequestDto.Code,
            Name = regionRequestDto.Name,
            RegionImageUrl = regionRequestDto.ImageUrl
        };

        _ctx.Regions.Add(regionDomainModel);
        _ctx.SaveChanges();

        var regionDto = new RegionDTO {
            Name = regionDomainModel.Name,
            Code = regionDomainModel.Code,
            ImageUrl = regionDomainModel.RegionImageUrl
        };

        return CreatedAtAction(nameof(GetRegionsById), new {id = regionDomainModel.Id}, regionDto);
    }

    [HttpPut]
    [Route("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult ChangeRegion([FromRoute] Guid? id, [FromBody] RegionDTO updateRegionDto) {
        if (id == null) {
            return NotFound("Envie um id para a request");
        }

        if (updateRegionDto == null) {
            return NoContent();
        }

        var regionToUpdate = _ctx.Regions.FirstOrDefault(r => r.Id == id);

        regionToUpdate.Code = updateRegionDto.Code;
        regionToUpdate.Name = updateRegionDto.Name;
        regionToUpdate.RegionImageUrl = updateRegionDto.ImageUrl;

        _ctx.SaveChanges();
        

        return Ok(updateRegionDto);
    }

    [HttpDelete]
    [Route("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult DeleteRegion([FromRoute] Guid? id) {
        if (id == null) {
            return BadRequest("Passe o id da trilha a ser deletada");
        }

        var regionToBeDeleted = _ctx.Regions.FirstOrDefault(r => r.Id == id);

        _ctx.Regions.Remove(regionToBeDeleted);
        _ctx.SaveChanges();

        return Ok("Região deletada com sucesso");
    }
}