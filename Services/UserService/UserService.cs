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
    public class UserService : IUserService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UserService(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<GetUserDto>> VerifySSN(string userName)
        {
            ServiceResponse<GetUserDto> response = new ServiceResponse<GetUserDto>();

            try
            {
                if (!string.IsNullOrWhiteSpace(userName)) { 
                    User user = await _context.Users
                                       .FirstOrDefaultAsync(u => u.UserName.ToLower() == userName.ToLower());
                response.Data = _mapper.Map<GetUserDto>(user);
               }
                else
                {
                    response.Success = false;
                    response.Message = "User Not found";
                }
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
