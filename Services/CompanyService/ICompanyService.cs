using CompanyOwnerWebAPI.Dtos;
using CompanyOwnerWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyOwnerWebAPI.Services
{
    public interface ICompanyService
    {
        Task<ServiceResponse<List<GetCompanyDto>>> AddCompany(AddCompanyDto newcompanyDto);

        Task<ServiceResponse<List<GetCompanyDto>>> GetAllCompanies();

        Task<ServiceResponse<GetCompanyDto>> GetCompanyDetail(int Id);

        Task<ServiceResponse<GetCompanyDto>> UpdateCompany(UpdateCompanyDto updateCompanyDto);
    }
}
