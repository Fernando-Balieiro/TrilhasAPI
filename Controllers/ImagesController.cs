using CaminhadasAPI.Interfaces;
using CaminhadasAPI.Models.Domain;
using CaminhadasAPI.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CaminhadasAPI.Controllers; 

[ApiController]
[Route("api/[controller]")]
public class ImagesController : ControllerBase {
    private readonly IImageRepository _imgs;

    public ImagesController(IImageRepository imgs) {
        _imgs = imgs;
    }
    
    //Post  -> api/Images/Upload
    [HttpPost]
    [Route("Upload")]
    public async Task<IActionResult> Upload([FromForm] ImageUploadRequestDto request) {
        ValidadeFileUpload(request);

        if (!ModelState.IsValid) {
            return BadRequest(ModelState);
        }
        
        // converter dto para domain model
        var imageDomainModel = new Image() {
            File = request.File,
            FileExtension = Path.GetExtension(request.File.FileName),
            FileSizeInBytes = request.File.Length,
            FileName = request.FileName,
            FileDescription = request.FileDescription,
        };

        await _imgs.Upload(imageDomainModel);
        return Ok(imageDomainModel);
    }

    private void ValidadeFileUpload(ImageUploadRequestDto req) {
        var allowedExtensions = new string[] {
            ".jpg",
            ".jpeg",
            ".png",
        };

        if (!allowedExtensions.Contains(Path.GetExtension(req.File.FileName))) {
            ModelState.AddModelError("arquivo", "extensão de arquivo não suportada");
        }

        if (req.File.Length > 10485760) {
            ModelState.AddModelError("arquivo", "O arquivo é muito pesado, ele deve ser menor que 10MB");
        }
    }
}