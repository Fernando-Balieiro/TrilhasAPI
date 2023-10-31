using System.ComponentModel.DataAnnotations;

namespace CaminhadasAPI.Models.Domain; 

public class Difficulty {
    [Key] public Guid Id { get; set; }
    [MaxLength(25)] public string? Name { get; set; }
}