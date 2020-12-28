using AutoMapper;
using CompanyOwnerWebAPI.Data;
using CompanyOwnerWebAPI.Dtos;
using CompanyOwnerWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyOwnerWebAPI.Services
{
    public class CompanyUserService : ICompanyUserService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public CompanyUserService(DataContext context,IMapper mapper)
        {
            _mapper = mapper;          
            _context = context;
        }
        public async Task<ServiceResponse<GetCompanyDto>> AddCompanyOwner(AddCompanyUserDto newCompanyUserDto)
        {
            ServiceResponse<GetCompanyDto> response = new ServiceResponse<GetCompanyDto>();
            try
            {
                Company company = await _context.Companies
                                        .Include(c => c.CompanyUsers).ThenInclude(cu => cu.User)
                                        .FirstOrDefaultAsync(c => c.Id == newCompanyUserDto.CompanyId);

                if (company == null)
                {
                    response.Success = false;
                    response.Message = "Company not found.";
                    return response;
                }

                User user = await _context.Users
                    .FirstOrDefaultAsync(u => u.Id == newCompanyUserDto.UserId);

                if (user == null)
                {
                    response.Success = false;
                    response.Message = "User not found";
                    return response;
                }

                Role role = await _context.Roles
                                    .FirstOrDefaultAsync( r => r.RoleName == "Owner");
                CompanyUser companyUser = new CompanyUser
                {
                    Company = company,
                    User = user,
                    Role = role
                };

                await _context.CompanyUsers.AddAsync(companyUser);
                await _context.SaveChangesAsync();

                response.Data = _mapper.Map<GetCompanyDto>(company);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

    }
}

