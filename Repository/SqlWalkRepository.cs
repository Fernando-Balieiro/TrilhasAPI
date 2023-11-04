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

    public async Task<List<Walk>?> GetAllWalks() {
        return await _ctx.Walks
            .Include(x => x.Difficulty)
            .Include(x => x.Region)
            .ToListAsync();
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