using API.Dtos;
using AutoMapper;
using Core.Entities.Settings;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Employee, EmployeeDto>()
            .ForMember(x => x.Office, o => o.MapFrom(s => s.Office.Name));

        }
    }
}