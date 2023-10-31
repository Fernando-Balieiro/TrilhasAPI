using System.ComponentModel.DataAnnotations;

namespace CaminhadasAPI.Models.Domain; 

public class Region {
    [Key] public Guid Id { get; set; }
    [Required] public string? Code { get; set; }
    [Required] public string? Name { get; set; }
    [Required] public string? RegionImageUrl { get; set; }
}