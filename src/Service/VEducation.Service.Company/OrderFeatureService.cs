using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEducation.Data.Model;
using VEducation.Data.ViewModels;

namespace VEducation.Service.Company
{
    public class OrderFeatureService : CompanyServiceBase, IOrderFeatureService
    {
        /// <summary>
        /// The repo
        /// </summary>
        private readonly IRepository<Feature> _repo;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderFeatureService"/> class.
        /// </summary>
        /// <param name="repo">
        /// The repo.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        public OrderFeatureService(IRepository<Feature> repo)
        {
            if (repo == null)
            {
                throw new ArgumentNullException("repo is null or empty");
            }
            _repo = repo;
        }

        public List<FeatureViewModel> GetAll()
        {
            return _repo.GetAll()
                .Select(x => new FeatureViewModel
                {
                     Description = x.Description,
                     Title = x.Title,
                })
                .ToList();
        }

    }
}
