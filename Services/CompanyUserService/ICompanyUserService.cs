using CompanyOwnerWebAPI.Dtos;
using CompanyOwnerWebAPI.Models;
using System.Threading.Tasks;

namespace CompanyOwnerWebAPI.Services
{
    public interface ICompanyUserService
    {
        Task<ServiceResponse<GetCompanyDto>> AddCompanyOwner(AddCompanyUserDto newCompanyUserDto);
    }
}
