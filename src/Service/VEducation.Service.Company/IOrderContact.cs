using Abp.Application.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using VAgency.Data.ViewModels;

namespace VEducation.Service.Company
{
    public interface IOrderContact : IApplicationService
    {
        List<CompanyContactViewModel> GetAll();
       Task<List<CompanyContactViewModel>> GetAllAsync();
    }
}