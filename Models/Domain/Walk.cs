using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CaminhadasAPI.Models.Domain; 

public class Walk {
    [Required] public Guid Id { get; set; }
    [Required] public string? Name { get; set; }
    [Required] public string? Description { get; set; }
    [Required] public double LengthInKm { get; set; }
    public string? WalkImageUrl { get; set; }
    
    [ForeignKey("Difficulty")] public Guid DifficultyId { get; set; }
    public Difficulty? Difficulty { get; set; }
    
    [ForeignKey("Region")] public Guid RegionId { get; set; }
    public Region? Region { get; set; }
}