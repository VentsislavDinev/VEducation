using Abp.Application.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using VAgency.Data.ViewModels;

namespace VEducation.Service.Company
{
    public interface IOrderAbout : IApplicationService
    {
        List<AboutViewModel> GetLast();
    }
}