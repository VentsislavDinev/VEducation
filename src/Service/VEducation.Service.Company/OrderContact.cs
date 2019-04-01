using Abp.Domain.Repositories;
using System;
using System.Threading.Tasks;
using VAgency.Data.ViewModels;
using VEducation.Data.Model;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

namespace VEducation.Service.Company
{
    public class OrderContact : CompanyServiceBase, IOrderContact
    {
        /// <summary>
        /// The repo
        /// </summary>
        private readonly IRepository<CompanyContact> _repo;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderContact"/> class.
        /// </summary>
        /// <param name="repo">
        /// The repo.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        public OrderContact(IRepository<CompanyContact> repo)
        {
            if (repo == null)
            {
                throw new ArgumentNullException("repo is null or empty");
            }
            _repo = repo;
        }

        public List<CompanyContactViewModel> GetAll()
        {
            return _repo.GetAll()
                .OrderByDescending(x => x.CreationTime)
                .Select(x => new CompanyContactViewModel
                {
                    Address = x.Address,
                    City = x.City,
                    Email = x.Email,
                    OfficeCountry = x.OfficeCountry,
                    Phonenumber = x.Phonenumber,
                    WorkFrom = x.WorkFrom,
                    WorkTo = x.WorkTo,
                })
                .ToList();
        }

        public async Task<List<CompanyContactViewModel>> GetAllAsync()
        {
            return await _repo.GetAll()
                .OrderByDescending(x => x.CreationTime)
                .Select(x => new CompanyContactViewModel
                {
                     Address = x.Address,
                     City = x.City,
                     Email = x.Email,
                     OfficeCountry = x.OfficeCountry,
                     Phonenumber = x.Phonenumber,
                     WorkFrom = x.WorkFrom,
                     WorkTo = x.WorkTo,
                })
                .ToListAsync();
        }
    }

}
