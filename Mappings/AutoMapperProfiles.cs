using AutoMapper;
using CaminhadasAPI.Models.Domain;
using CaminhadasAPI.Models.DTOs;

namespace CaminhadasAPI.Mappings; 

public class AutoMapperProfiles : Profile {
    public AutoMapperProfiles() {
        CreateMap<Region, RegionDTO>().ReverseMap();
    }
}