using Abp.Domain.Repositories;
using Education.Data.Models;
using System;
using System.Threading.Tasks;
using VAgency.Data.ViewModels;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

namespace VEducation.Service.Company
{
    public class OrderFeedback : CompanyServiceBase, IOrderFeedback
    {
        /// <summary>
        /// The repo
        /// </summary>
        private readonly IRepository<CompanyFeedBackCompany> _repo;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderFeedback"/> class.
        /// </summary>
        /// <param name="repo">
        /// The repo.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        public OrderFeedback(IRepository<CompanyFeedBackCompany> repo)
        {
            if (repo == null)
            {
                throw new ArgumentNullException("repo is null");
            }
            _repo = repo;
        }

        public List<CompanyFeedBackCompanyViewModel> GetAll()
        {
            return  _repo.GetAll()
                .OrderByDescending(x => x.CreatedOn)
                .Take(5)
                .Select(x => new CompanyFeedBackCompanyViewModel
                {
                     CompanyName = x.CompanyName,
                    Description = x.Description,
                     CompanyLogos = x.CompanyLogos,
                })
                .ToList();
        }
    }
}
