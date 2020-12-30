using AutoMapper;
using CompanyOwnerWebAPI.Dtos;
using CompanyOwnerWebAPI.Models;
using System.Linq;

namespace CompanyOwnerWebAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AddCompanyDto, Company>();

            CreateMap<Company, GetCompanyDto>()
                  .ForMember(dto => dto.UserDetails, c => c.MapFrom(c => c.CompanyUsers.Select(cu => cu.User)));

            CreateMap<User, GetUserDto>();

            CreateMap<UpdateCompanyDto, Company>();
        }
    }
}
