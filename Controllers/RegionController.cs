using AutoMapper;
using CaminhadasAPI.Data;
using CaminhadasAPI.Interfaces;
using CaminhadasAPI.Models.Domain;
using CaminhadasAPI.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CaminhadasAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RegionController : ControllerBase{
    private readonly IRegionRepository _repo;
    private readonly IMapper _mapper;

    public RegionController(IRegionRepository repo, IMapper mapper) {
        _repo = repo;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllRegions() {
        var regions = await _repo.GetAllRegions();

        /*
        var regionsDto = regions
            .Select(region => new RegionDTO() 
                { 
                Code = region.Code,
                Name = region.Name,
                RegionImageUrl = region.RegionImageUrl 
                })
            .ToList();
        */

        // Transforma map domain model para DTO
        var regionsDto = _mapper.Map<List<RegionDto>>(regions);

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

        var regionDto = new RegionDto {
            Name = region.Name,
            Code = region.Code,
            RegionImageUrl = region.RegionImageUrl
        };

        return Ok(regionDto);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateRegion([FromBody] RegionDto? regionRequestDto) {
        if (regionRequestDto == null) {
            return BadRequest("Você deve passar uma região");
        }

        if (!ModelState.IsValid) {
            return BadRequest("Envie um model válido para o post");
        }
        var regionDomainModel = new Region {
            Code = regionRequestDto.Code,
            Name = regionRequestDto.Name,
            RegionImageUrl = regionRequestDto.RegionImageUrl
        };

        await _repo.Create(regionDomainModel);

        var regionDto = new RegionDto {
            Name = regionDomainModel.Name,
            Code = regionDomainModel.Code,
            RegionImageUrl = regionDomainModel.RegionImageUrl
        };

        return CreatedAtAction(nameof(GetRegionsById), new {id = regionDomainModel.Id}, regionDto);
    }

    [HttpPut]
    [Route("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ChangeRegion([FromRoute] Guid? id, [FromBody] RegionDto? updateRegionDto) {
        // var regionDomainModel = new Region {
        //     Code = updateRegionDto.Code,
        //     Name = updateRegionDto.Name,
        //     RegionImageUrl = updateRegionDto.RegionImageUrl,
        // };
        var updateRegionDomain = _mapper.Map<Region>(updateRegionDto);
        
        if (id == null) {
            return NotFound("Envie um id para a request");
        }

        if (updateRegionDto == null) {
            return NoContent();
        }

        if (!ModelState.IsValid) {
            return BadRequest("Passe um modelo válido para a request");
        }

        var regionToUpdate = await _repo.Update(id, updateRegionDomain);

        return Ok(regionToUpdate);
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

        var regionDto = new RegionDto {
            Name = regionDomainModel.Name,
            Code = regionDomainModel.Code,
            RegionImageUrl = regionDomainModel?.RegionImageUrl
        };

        return Ok(regionDto);
    }
}