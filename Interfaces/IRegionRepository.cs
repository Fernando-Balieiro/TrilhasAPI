using CaminhadasAPI.Models.Domain;
using CaminhadasAPI.Models.DTOs;

namespace CaminhadasAPI.Interfaces; 

public interface IRegionRepository {
    Task<List<Region>> GetAllRegions();
    Task<Region?> GetRegionById(Guid? id);
    Task<Region> Create(Region region);

    Task<RegionDto?> Update(Guid? id, Region? regionToUpdate);
    Task<Region?> Delete(Guid? id);

}