using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAgency.Data.ViewModels;
using VEducation.Data.Model;

namespace VEducation.Service.Company
{
    public class OrderAbout : CompanyServiceBase, IOrderAbout
    {
        /// <summary>
        /// The repo
        /// </summary>
        private IRepository<About> _repo;


        public OrderAbout(IRepository<About> repo)
        {
            if (repo == null)
            {
                throw new ArgumentNullException("repo is null or empty");
            }

            this._repo = repo;
        }

        public List<AboutViewModel> GetLast()
        {
            return _repo.GetAll()
                .OrderByDescending(x => x.CreationTime)
                .Select(x => new AboutViewModel
                {
                     Description = x.Description,
                     Name = x.Name
                })
                .ToList();
        }
    }
}
