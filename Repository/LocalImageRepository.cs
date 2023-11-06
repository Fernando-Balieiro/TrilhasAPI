using CaminhadasAPI.Data;
using CaminhadasAPI.Interfaces;
using CaminhadasAPI.Models.Domain;

namespace CaminhadasAPI.Repository; 

public class LocalImageRepository : IImageRepository {
    private readonly IWebHostEnvironment _webHostEnv;
    private readonly IHttpContextAccessor _httpAcessor;
    private readonly AppDbContext _ctx;

    public LocalImageRepository(IWebHostEnvironment webHostEnv, IHttpContextAccessor httpAcessor, AppDbContext ctx) {
        _webHostEnv = webHostEnv;
        _httpAcessor = httpAcessor;
        _ctx = ctx;
    }
    public async Task<Image> Upload(Image img) {
        var localFilePath = Path
            .Combine(_webHostEnv.ContentRootPath, "Images", $"{img.FileName}{img.FileExtension}");
        //Upload imagem para path local
        using var stream = new FileStream(localFilePath, FileMode.Create);
        await img.File.CopyToAsync(stream);
        
        //https://localhost/8080/images/image.jpg
        var urlFilePath = $"{_httpAcessor.HttpContext.Request.Scheme}://{_httpAcessor.HttpContext.Request.Host}{_httpAcessor.HttpContext.Request.PathBase}/Images/{img.FileName}{img.FileExtension}";
        img.FilePath = urlFilePath;
        //adicionar imagens para db

        await _ctx.Images.AddAsync(img);
        await _ctx.SaveChangesAsync();

        return img;

    }
}