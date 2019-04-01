using Abp.Application.Services;
using System.Threading.Tasks;
using VEducation.Data.Model;

namespace VEducation.Service.Company
{
    public interface ITeamSocialLinkService : IApplicationService
    {
        Task<TeamSocialLink> Create(int teamId, string filePath, string url);
        Task<TeamSocialLink> Delete(int teamId, string filePath, string url);
        Task<TeamSocialLink> Update(int teamId, string filePath, string url);
    }
}