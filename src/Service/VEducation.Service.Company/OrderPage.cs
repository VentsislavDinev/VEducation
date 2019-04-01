using Abp.Domain.Repositories;
using Education.Data.Models.Company;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAgency.Data.ViewModels;

namespace VEducation.Service.Company
{
    public class OrderPage : CompanyServiceBase, IOrderPage
    {
        /// <summary>
        /// The repository
        /// </summary>
        private IRepository<StaticPage> _repository;


        /// <summary>
        /// Initializes a new instance of the <see cref="OrderPage"/> class.
        /// </summary>
        /// <param name="repo">The repo.</param>
        public OrderPage(IRepository<StaticPage> repo)
        {
            if (repo == null)
            {
                throw new ArgumentNullException("repo is null or empty");
            }
            this._repository = repo;
        }

        public async Task<StaticPageViewModel> GetByName(string name)
        {
            return await _repository.GetAll()
                .Where(x => x.Name == name)
                .Select(x => new StaticPageViewModel
                {
                    Name = x.Name, 
                    CreatedOn = x.CreatedOn,
                    Description = x.Description,
                })
                .FirstOrDefaultAsync();
        }

        public async Task<List<StaticPageViewModel>> GetAll()
        {
            return await _repository.GetAll()
                .OrderByDescending(x => x.CreatedOn)
                .Take(10)
                .Skip(10)
                .Select(x => new StaticPageViewModel
                {
                     Name = x.Name,
                })
                .ToListAsync();
        }
    }
}
