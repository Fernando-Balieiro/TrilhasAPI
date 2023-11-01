using CaminhadasAPI.Data;
using CaminhadasAPI.Interfaces;
using CaminhadasAPI.Models.Domain;
using CaminhadasAPI.Models.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CaminhadasAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RegionController : ControllerBase{
    private readonly AppDbContext _ctx;
    private readonly IRegionRepository _repo;

    public RegionController(AppDbContext ctx, IRegionRepository repo) {
        _ctx = ctx;
        _repo = repo;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllRegions() {
        var regions = await _repo.GetAllRegions();

        var regionsDto = regions
            .Select(region => new RegionDTO() 
                { 
                Code = region.Code,
                Name = region.Name,
                ImageUrl = region.RegionImageUrl 
                })
            .ToList();

        return Ok(regionsDto);
    }

    [HttpGet]
    [Route("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetRegionsById([FromRoute] Guid? id) {
        if (id == null) {
            return NotFound("Id passed was null");
        }

        var region = await _repo.GetRegionById(id);
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
    public async Task<IActionResult> CreateRegion([FromBody] RegionDTO? regionRequestDto) {
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

        await _repo.Create(regionDomainModel);

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
    public async Task<IActionResult> ChangeRegion([FromRoute] Guid? id, [FromBody] RegionDTO? updateRegionDto) {
        var regionDomainModel = new Region {
            Code = updateRegionDto.Code,
            Name = updateRegionDto.Name,
            RegionImageUrl = updateRegionDto.ImageUrl,
        };
        
        if (id == null) {
            return NotFound("Envie um id para a request");
        }

        if (updateRegionDto == null) {
            return NoContent();
        }

        if (!ModelState.IsValid) {
            return BadRequest("Passe um modelo válido para a request");
        }

        var regionToUpdate = _ctx.Regions.FirstOrDefault(r => r.Id == id);

        if (regionToUpdate == null) {
            return NotFound("Não foi encontrada a região para ser atualizada");
        }

        var updatedRegion = await _repo.Update(id, regionDomainModel);
        return Ok(updatedRegion);
    }

    [HttpDelete]
    [Route("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteRegion([FromRoute] Guid? id) {
        var regionDomainModel = await _repo.Delete(id);

        if (regionDomainModel is null) {
            return NotFound();
        }

        var regionDto = new RegionDTO {
            Name = regionDomainModel.Name,
            Code = regionDomainModel.Code,
            ImageUrl = regionDomainModel?.RegionImageUrl
        };

        return Ok(regionDto);
    }
}