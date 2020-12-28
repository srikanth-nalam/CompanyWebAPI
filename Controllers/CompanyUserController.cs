using CompanyOwnerWebAPI.Dtos;
using CompanyOwnerWebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyOwnerWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyUserController : ControllerBase
    {
        private readonly ICompanyUserService _companyUserService;
        public CompanyUserController(ICompanyUserService companyUserService)
        {
            _companyUserService = companyUserService;
        }

        [HttpPost("CompanyOwner")]
        public async Task<IActionResult> AddCompanyUser(AddCompanyUserDto newCompanyUser)
        {
            return Ok(await _companyUserService.AddCompanyOwner(newCompanyUser));
        }
    }
}
