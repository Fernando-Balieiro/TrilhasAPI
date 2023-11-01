using CaminhadasAPI.Models.Domain;

namespace CaminhadasAPI.Interfaces; 

public interface IRegionRepository {
    Task<List<Region?>> GetAllRegions();
    Task<Region?> GetRegionById(Guid? id);
    Task<Region> Create(Region region);

    Task<Region?> Update(Guid? id, Region? regionToUpdate);
    Task<Region?> Delete(Guid? id);

}