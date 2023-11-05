using AutoMapper;
using CaminhadasAPI.Models.Domain;
using CaminhadasAPI.Models.DTOs;

namespace CaminhadasAPI.Mappings; 

public class AutoMapperProfiles : Profile {
    public AutoMapperProfiles() {
        CreateMap<Region, RegionDto>().ReverseMap();
        CreateMap<Walk, WalkDto>().ReverseMap();
        CreateMap<Difficulty, DifficultyDto>().ReverseMap();
        CreateMap<AddWalkRequestDto, Walk>().ReverseMap();
        CreateMap<UpdateWalkDto, Walk>().ReverseMap();
    }
}