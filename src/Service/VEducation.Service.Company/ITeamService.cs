using Abp.Application.Services;
using System.Threading.Tasks;
using VEducation.Data.Model;

namespace VEducation.Service.Company
{
    public interface ITeamService :  IApplicationService
    {
        Task<Team> Create(string title, string filePath, string position, string firstName, string lastName, string desc);
        Task<Team> Delete(string title, string filePath, string position, string firstName, string lastName, string desc);
        Task<Team> Update(string title, string filePath, string position, string firstName, string lastName, string desc);
    }
}