using Abp.Domain.Repositories;
using Education.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using VAgency.Data.ViewModels.Company;

namespace VEducation.Service.Company
{
    public class OrderMessageCompany : CompanyServiceBase, IOrderMessageCompany
    {
        /// <summary>
        /// The repo
        /// </summary>
        private readonly IRepository<CompanyMessage> _repo;

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageCompany"/> class.
        /// </summary>
        /// <param name="repo">
        /// The repo.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        public OrderMessageCompany(IRepository<CompanyMessage> repo)
        {
            if (repo == null)
            {
                throw new ArgumentNullException("repo is null or empty");
            }

            _repo = repo;
        }

        public async Task<List<CompanyMessageViewModel>> GetAll()
        {
            return await _repo.GetAll()
                .OrderByDescending(x => x.CreatedOn)
                .Take(10)
                .Skip(10)
                .Select(x => new CompanyMessageViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    CreationTime = x.CreatedOn,
                })
                .ToListAsync();
        }

        public async Task<CompanyMessageViewModel> GetById(int id)
        {
            return await _repo.GetAll()
                .Where(x => x.Id == id)
                .Select(x => new CompanyMessageViewModel
                {
                    CreationTime = x.CreatedOn,
                    Description = x.Description,
                    Email = x.Email,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Phone = x.Phone,
                    Title = x.Title,
                })
                .FirstOrDefaultAsync();
        }
    }
}
