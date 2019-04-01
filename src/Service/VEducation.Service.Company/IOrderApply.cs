using Abp.Application.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using VEducation.Data.ViewModels;

namespace VEducation.Service.Company
{
    public interface IOrderApply : IApplicationService
    {
        Task<List<ApplyViewModel>> GetAll();
        Task<ApplySingleViewModel> GetByName(string name);
    }
}