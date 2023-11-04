using CaminhadasAPI.Models.Domain;
using CaminhadasAPI.Models.DTOs;

namespace CaminhadasAPI.Interfaces; 

public interface IWalksRepository {
    Task<Walk> CreateWalk(Walk walk);
    Task<List<Walk>?> GetAllWalks();
    Task<Walk?> GetById(Guid id);
    Task<Walk?> UpdateAsync(Guid id, Walk walk);
    Task<Walk?> DeleteAsync(Guid id);
}