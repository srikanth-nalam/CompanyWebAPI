using AutoMapper;
using CompanyOwnerWebAPI.Dtos;
using CompanyOwnerWebAPI.Models;


namespace CompanyOwnerWebAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AddCompanyDto, Company>();

            CreateMap<Company, GetCompanyDto>();

            CreateMap<User, GetUserDto>();

            CreateMap<UpdateCompanyDto, Company>();
        }
    }
}
