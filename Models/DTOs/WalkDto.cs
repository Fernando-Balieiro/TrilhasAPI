using CaminhadasAPI.Models.Domain;

namespace CaminhadasAPI.Models.DTOs; 

public class WalkDto {
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public double LengthInKm { get; set; }
    public string? WalkImageUrl { get; set; }

    public string? RegionId { get; set; }
    public Region? Region { get; set; }
    public string? DifficultyId { get; set; }
    public Difficulty? Difficulty { get; set; }
}