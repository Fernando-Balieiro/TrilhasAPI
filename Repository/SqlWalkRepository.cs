using CaminhadasAPI.Data;
using CaminhadasAPI.Interfaces;
using CaminhadasAPI.Models.Domain;
using CaminhadasAPI.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace CaminhadasAPI.Repository; 

public class SqlWalkRepository : IWalksRepository{
    private readonly AppDbContext _ctx;

    public SqlWalkRepository(AppDbContext ctx) {
        _ctx = ctx;
    }
    
    public async Task<Walk> CreateWalk(Walk walk) {
        await _ctx.Walks.AddAsync(walk);
        await _ctx.SaveChangesAsync();
        return walk;
    }

    public async Task<List<Walk>?> GetAllWalks
        (string? filterOn = null, string? filterQuery = null,
            string? sortBy = null, bool isAscending = true,
            int pageNumber = 1, int pageSize = 1000) {
        var walks = _ctx.Walks
            .Include(x => x.Difficulty)
            .Include(x => x.Region)
            .AsQueryable();

        
        // Filtrando
        if (string.IsNullOrWhiteSpace(filterOn) == false &&
            string.IsNullOrWhiteSpace(filterQuery) == false) {
            
            if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase)) {
                walks = walks.Where(x => x.Name.Contains(filterQuery));
            }
        }

        // Sorting do array
        if (string.IsNullOrWhiteSpace(sortBy) != false) return await walks.ToListAsync();
        {
            if (sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase)) {
                walks = isAscending ? walks.OrderBy(x => x.Name) : walks.OrderByDescending(x => x.Name);
            } else if (sortBy.Equals("Length", StringComparison.OrdinalIgnoreCase)) {
                walks = isAscending ? 
                    walks.OrderBy(x => x.LengthInKm) 
                    : walks.OrderByDescending(x => x.LengthInKm);
            }
        }

        var skipedResults = (pageNumber - 1) * pageSize;
        
        return await walks.Skip(skipedResults).Take(pageSize).ToListAsync();
    }


    public async Task<Walk?> GetById(Guid id) {
        return await _ctx.Walks
            .Include(x => x.Region)
            .Include(x => x.Difficulty)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Walk?> UpdateAsync(Guid id, Walk walk) {
        var existingWalk = await _ctx.Walks.FirstOrDefaultAsync(x => x.Id == id);

        if (existingWalk is null) {
            return null;
        }

        existingWalk.Name = walk.Name;
        existingWalk.Description = walk.Description;
        existingWalk.LengthInKm = walk.LengthInKm;
        existingWalk.WalkImageUrl = walk.WalkImageUrl;
        existingWalk.DifficultyId = walk.DifficultyId;
        existingWalk.RegionId = walk.RegionId;

        await _ctx.SaveChangesAsync();
        return existingWalk;
    }

    public async Task<Walk?> DeleteAsync(Guid id) {
        var walkToBeDeleted = await _ctx.Walks
            .Include(x => x.Region)
            .Include(x => x.Difficulty)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (walkToBeDeleted is null) {
            return null;
        }

        _ctx.Walks.Remove(walkToBeDeleted);
        await _ctx.SaveChangesAsync();
        return walkToBeDeleted;
    }
}