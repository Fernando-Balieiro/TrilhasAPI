using CaminhadasAPI.Models.Domain;
using CaminhadasAPI.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CaminhadasAPI.Interfaces; 

public interface IWalksRepository {
    Task<Walk> CreateWalk(Walk walk);
    Task<List<Walk>?> GetAllWalks
        (string? filterOn = null, string? filterQuery = null, string? sortBy = null, bool isAscending = true,
        int pageNumber = 1, int pageSize = 1000);
    Task<Walk?> GetById(Guid id);
    Task<Walk?> UpdateAsync(Guid id, Walk walk);
    Task<Walk?> DeleteAsync(Guid id);
}