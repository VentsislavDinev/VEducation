using System.Threading.Tasks;
using VEducation.Data.Model;

namespace VEducation.Service.Company
{
    public interface IGalleryService
    {
        Task<Gallery> Create(string title);
        Task<Gallery> Delete(string title);
        Task<Gallery> Update(string title);
    }
}