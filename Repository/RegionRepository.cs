using CaminhadasAPI.Data;
using CaminhadasAPI.Interfaces;
using CaminhadasAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CaminhadasAPI.Repository; 

public class RegionRepository : IRegionRepository{
    private readonly AppDbContext _ctx;

    public RegionRepository(AppDbContext ctx) {
        _ctx = ctx;
    }
    
    public async Task<List<Region?>> GetAllRegions() {
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

    public async Task<Region?> Update(Guid? id, Region? regionToUpdate) {
        var existingRegion = await _ctx.Regions.FirstOrDefaultAsync(r => r.Id == id);

        existingRegion.Code = regionToUpdate.Code;
        existingRegion.Name = regionToUpdate.Name;
        existingRegion.RegionImageUrl = regionToUpdate.RegionImageUrl;

        await _ctx.SaveChangesAsync();
        return existingRegion;
    }

    public async Task<Region?> Delete(Guid? id) {
        if (id is null) {
            return null;
        }
        
        var deletedRegion = await _ctx.Regions
            .FirstOrDefaultAsync(x => x.Id == id);

        _ctx.Regions.Remove(deletedRegion);
        await _ctx.SaveChangesAsync();
        return deletedRegion;
    }
}