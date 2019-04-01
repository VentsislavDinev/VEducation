using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using VEducation.Data.Model;
using VEducation.Data.ViewModels;

namespace VEducation.Service.Company
{
    public class OrderApply : IOrderApply
    {
        /// <summary>
        /// The repo
        /// </summary>
        private readonly IRepository<Apply> _repo;


        public OrderApply(IRepository<Apply> repo)
        {
            if (repo == null)
            {
                throw new ArgumentNullException("repo is null or empty");
            }

            _repo = repo;
        }

        public async Task<List<ApplyViewModel>> GetAll()
        {
            List<ApplyViewModel> getAll = await _repo.GetAll()
                .OrderByDescending(x => x.CreatedOn)
                .Take(10)
                .Skip(10)
                .Select(x => new ApplyViewModel
                {

                })
                .ToListAsync();

            return getAll;
        }

        public async Task<ApplySingleViewModel> GetByName(string name)
        {
            return await _repo.GetAll()
                 .Where(x => x.FirstName == name)
                 .Select(x => new ApplySingleViewModel
                 {
                     FirstName = x.FirstName,
                     LastName = x.LastName,
                     CreatedOn = x.CreatedOn,
                     Description = x.Description,
                     Email = x.Email,
                     PhoneNumber = x.PhoneNumber,
                 })
                 .FirstOrDefaultAsync();
        }
    }
}
