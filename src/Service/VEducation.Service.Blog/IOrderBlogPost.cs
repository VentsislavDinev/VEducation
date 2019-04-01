using Abp.Application.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using VAgency.Data.ViewModels;

namespace VEducation.Service.Blog
{
    public interface IOrderBlogPost : IApplicationService
    {
        Task<List<BlogPostVieModel>> GetAll();
        Task<BlogPostAnswerVieModel> GetAnswerByBlogPost(int id);
        Task<List<BlogPostCategoryViewModel>> GetBlogCategory();
        Task<int> GetBlogCategoryCount();
        Task<BlogPostVieModel> GetById(int id);
    }
}