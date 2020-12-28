using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CompanyOwnerWebAPI.Data;
using CompanyOwnerWebAPI.Dtos;
using CompanyOwnerWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyOwnerWebAPI.Services
{
    public class CompanyService: ICompanyService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public CompanyService(IMapper mapper,DataContext dataContext)
        {
            _mapper = mapper;
            _context = dataContext;
        }

        /// <summary>
        /// Add Company to the existing list
        /// </summary>
        /// <param name="newcompanyDto"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<List<GetCompanyDto>>> AddCompany(AddCompanyDto newcompanyDto)
        {
            ServiceResponse<List<GetCompanyDto>> serviceResponse = new ServiceResponse<List<GetCompanyDto>>();
            Company company = _mapper.Map<Company>(newcompanyDto);
          
            await _context.Companies.AddAsync(company);
            await _context.SaveChangesAsync();
            serviceResponse.Data = (_context.Companies.Select(c => _mapper.Map<GetCompanyDto>(c))).ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCompanyDto>>> GetAllCompanies()
        {
            ServiceResponse<List<GetCompanyDto>> serviceResponse = new ServiceResponse<List<GetCompanyDto>>();
               List<Company> dbCompanies =
                  await _context.Companies.ToListAsync();

            serviceResponse.Data = (dbCompanies.Select(c => _mapper.Map<GetCompanyDto>(c))).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCompanyDto>> GetCompanyDetail(int Id)
        {
            ServiceResponse<GetCompanyDto> serviceResponse = new ServiceResponse<GetCompanyDto>();

            Company dbCompany = await _context.Companies             
               .Include(c => c.CompanyUsers).ThenInclude(cu => cu.User)
               .FirstOrDefaultAsync(c => c.Id == Id);  
            serviceResponse.Data = _mapper.Map<GetCompanyDto>(dbCompany);
            return serviceResponse;
        }


        public async Task<ServiceResponse<GetCompanyDto>> UpdateCompany(UpdateCompanyDto updateCompanyDto)
        {
            ServiceResponse<GetCompanyDto> serviceResponse = new ServiceResponse<GetCompanyDto>();
            try
            {
                Company company = await _context.Companies.Include(c => c.CompanyUsers).FirstOrDefaultAsync(c => c.Id == updateCompanyDto.Id);               
                if (company != null)
                {
                    company.CompanyName = updateCompanyDto.CompanyName;
                    company.PhoneNumber = updateCompanyDto.PhoneNumber;
                    company.Country = updateCompanyDto.Country;
                    

                    _context.Companies.Update(company);
                    await _context.SaveChangesAsync();

                    serviceResponse.Data = _mapper.Map<GetCompanyDto>(company);
                }
                else
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Company not found.";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
    }
}
