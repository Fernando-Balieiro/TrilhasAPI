using CaminhadasAPI.Data;
using CaminhadasAPI.Interfaces;
using CaminhadasAPI.Models.Domain;
using CaminhadasAPI.Models.DTOs;

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

    public Task<List<Walk>> GetAllWalks(string? filterOn = null, string? filterQuery = null, string? sortBy = null, bool isAscending = true,
        int pageNumber = 1, int pageSize = 1000) {
        throw new NotImplementedException();
    }

    public Task<Walk?> GetById(Guid id) {
        throw new NotImplementedException();
    }

    public Task<Walk?> UpdateAsync(Guid id, Walk walk) {
        throw new NotImplementedException();
    }

    public Task<Walk?> DeleteAsync(Guid id) {
        throw new NotImplementedException();
    }
}