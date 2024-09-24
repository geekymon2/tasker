using AutoMapper;

namespace GeekyMon2.Tasker.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Entities.Task, Models.TaskDto>();
    }
}