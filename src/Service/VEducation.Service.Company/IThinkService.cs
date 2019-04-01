using Abp.Application.Services;
using System.Threading.Tasks;
using VEducation.Data.Model;

namespace VEducation.Service.Company
{
    public interface IThinkService : IApplicationService
    {
        Task<Think> Create(string title, string desc);
        Task<Think> Delete(string title, string desc);
        Task<Think> Update(string title, string desc);
    }
}