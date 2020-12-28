using CompanyOwnerWebAPI.Dtos;
using CompanyOwnerWebAPI.Models;
using System.Threading.Tasks;

namespace CompanyOwnerWebAPI.Services
{
    public interface IUserService
    {
        Task<ServiceResponse<GetUserDto>> VerifySSN(string userName);
    }
}
