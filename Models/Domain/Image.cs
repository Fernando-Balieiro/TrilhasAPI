using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CaminhadasAPI.Models.Domain; 

public class Image {
    [Key] public Guid Id { get; set; }
    [NotMapped] public IFormFile File { get; set; }
    [Required] public string FileName { get; set; }
    public string? FileDescription { get; set; }
    public string FileExtension { get; set; }
    public long FileSizeInBytes { get; set; }
    public string FilePath { get; set; }
}