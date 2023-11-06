using System.Net;
using CaminhadasAPI.Models.Domain;

namespace CaminhadasAPI.Interfaces; 

public interface IImageRepository {
    Task<Image> Upload(Image img);
}