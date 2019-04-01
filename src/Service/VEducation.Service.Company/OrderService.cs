using Abp.Domain.Repositories;
using Education.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAgency.Data.ViewModels;

namespace VEducation.Service.Company
{
    public class OrderService : IOrderService
    {
        /// <summary>
        /// The repo
        /// </summary>
        private IRepository<CompanyInformation> _repo;

        /// <summary>
        /// Initializes a new instance of the <see cref="Service"/> class. 
        /// </summary>
        /// <param name="repo">
        /// The company system data.
        /// </param>
        public OrderService(IRepository<CompanyInformation> repo)
        {
            if (repo == null)
            {
                throw new ArgumentNullException("repo is null or empty");
            }

            this._repo = repo;
        }

        public List<CompanyInformationViewModel> GetAll()
        {
            return _repo.GetAll()
                .Select(x => new CompanyInformationViewModel
                {
                    Description = x.Description,
                    Name = x.Name,

                })
                .ToList();
        }
    }
}
