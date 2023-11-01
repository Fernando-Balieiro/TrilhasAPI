using AutoMapper;
using CaminhadasAPI.Data;
using CaminhadasAPI.Interfaces;
using CaminhadasAPI.Models.Domain;
using CaminhadasAPI.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace CaminhadasAPI.Repository; 

public class RegionRepository : IRegionRepository{
    private readonly AppDbContext _ctx;
    private readonly IMapper _mapper;

    public RegionRepository(AppDbContext ctx, IMapper mapper) {
        _ctx = ctx;
        _mapper = mapper;
    }
    
    public async Task<List<Region>> GetAllRegions() {
        return await _ctx.Regions.ToListAsync();
    }

    public async Task<Region?> GetRegionById(Guid? id) {
        return await _ctx.Regions.FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<Region> Create(Region region) {
        _ctx.Regions.Add(region);
        await _ctx.SaveChangesAsync();
        return region;
    }

    public async Task<RegionDTO?> Update(Guid? id, Region? regionToUpdate) {
        var existingRegion = await _ctx.Regions.FirstOrDefaultAsync(r => r.Id == id);

        if (existingRegion is null) {
            return null;
        }

        existingRegion.Code = regionToUpdate?.Code;
        existingRegion.Name = regionToUpdate?.Name;
        existingRegion.RegionImageUrl = regionToUpdate?.RegionImageUrl;

        var updatedRegionDto = _mapper.Map<RegionDTO>(existingRegion);
        
        await _ctx.SaveChangesAsync();
        return updatedRegionDto;
    }

    public async Task<Region?> Delete(Guid? id) {
        if (id is null) {
            return null;
        }
        
        var deletedRegion = await _ctx.Regions
            .FirstOrDefaultAsync(x => x.Id == id);

        if (deletedRegion is null) {
            return null;
        }

        _ctx.Regions.Remove(deletedRegion);
        await _ctx.SaveChangesAsync();
        return deletedRegion;
    }


}