using AutoMapper;
using CaminhadasAPI.Interfaces;
using CaminhadasAPI.Models.Domain;
using CaminhadasAPI.Models.DTOs;
using CaminhadasAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CaminhadasAPI.Controllers; 

[ApiController]
[Route("api/[controller]")]
public class WalksController : ControllerBase{
    private readonly IMapper _mapper;
    private readonly IWalksRepository _repo;

    public WalksController(IMapper mapper, IWalksRepository repo) {
        _mapper = mapper;
        _repo = repo;
    }
    
    // Criar uma trilha
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto) {
        var walkDomainModel = _mapper.Map<Walk>(addWalkRequestDto);
        await _repo.CreateWalk(walkDomainModel);
        return Ok(_mapper.Map<AddWalkRequestDto>(walkDomainModel));
    }

    [HttpGet]
    public async Task<IActionResult> 
        GetAll([FromQuery] string? filterOn, 
            [FromQuery] string? filterQuery, 
            [FromQuery] string? sortBy, 
            [FromQuery] bool? isAscending,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 1000) {
        var walkList = await _repo.GetAllWalks(filterOn, filterQuery, sortBy, isAscending ?? true, pageNumber, pageSize);
        if (walkList == null) {
            return NoContent();
        }
        return Ok(_mapper.Map<List<WalkDto>>(walkList));
    }

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetWalkById(Guid id) {
        var walkById = await _repo.GetById(id);
        if (walkById is null) {
            return NotFound();
        }

        return Ok(_mapper.Map<WalkDto>(walkById));
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> UpdateWalk([FromRoute] Guid id, [FromBody] UpdateWalkDto updateWalkDto) {
        if (!ModelState.IsValid) {
            return BadRequest("Passe uma request válida");
        }
        var walkDomainModel = _mapper.Map<Walk>(updateWalkDto);
        if (walkDomainModel is null) {
            return NotFound("Nada foi encontrado no banco de dados");
        }

        await _repo.UpdateAsync(id, walkDomainModel);
        return Ok(_mapper.Map<WalkDto>(walkDomainModel));
    }

    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<IActionResult> DeleteById([FromRoute] Guid id) {
        var deletedWalk = await _repo.DeleteAsync(id);

        if (deletedWalk is null) {
            return BadRequest();
        }

        return Ok(_mapper.Map<WalkDto>(deletedWalk));

    }
}