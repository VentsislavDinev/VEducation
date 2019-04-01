using Abp.Application.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using VAgency.Data.ViewModels.Company;

namespace VEducation.Service.Company
{
    public interface IOrderMessageCompany : IApplicationService
    {
        Task<List<CompanyMessageViewModel>> GetAll();
        Task<CompanyMessageViewModel> GetById(int id);
    }
}