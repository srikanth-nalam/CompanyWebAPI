using CompanyOwnerWebAPI.Dtos;
using CompanyOwnerWebAPI.Models;
using CompanyOwnerWebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyOwnerWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly ILogger<CompanyController> _companyController;
        public CompanyController(ICompanyService companyService,ILogger<CompanyController> companyController)
        {
            _companyService = companyService;
            _companyController = companyController;

        }

        [HttpPost]
        public async Task<IActionResult> AddCompany(AddCompanyDto newCompanyDto)
        {
            return Ok(await _companyService.AddCompany(newCompanyDto));
        }

        [HttpGet("GetAll")]      
        public async Task<IActionResult> Get()
        {
            return Ok(await _companyService.GetAllCompanies());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompanyDetail(int Id)
        {
            return Ok(await _companyService.GetCompanyDetail(Id)); 
            
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCompanyDetail(UpdateCompanyDto updateCompanyDto)
        {
            ServiceResponse<GetCompanyDto> response = await _companyService.UpdateCompany(updateCompanyDto);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}
