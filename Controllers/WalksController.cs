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
    public async Task<IActionResult> GetAll() {
        var walkList = await _repo.GetAllWalks();
        if (walkList == null) {
            return NoContent();
        }
        return Ok(_mapper.Map<List<WalkDto>>(walkList));
    }
}