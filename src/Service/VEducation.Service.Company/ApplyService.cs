using Abp.Domain.Repositories;
using System;
using System.Threading.Tasks;
using VEducation.Data.Model;

namespace VEducation.Service.Company
{
    public class ApplyService : CompanyServiceBase, IApplyService
    {
        /// <summary>
        /// The repo
        /// </summary>
        private readonly IRepository<Apply> _repo;


        public ApplyService(IRepository<Apply> repo)
        {
            if (repo == null)
            {
                throw new ArgumentNullException("repo is null or empty");
            }

            _repo = repo;
        }

        public async Task<Apply> Create(string email, string desc, string firstName, string lastName, string phoneNumber, DateTime createdOn)
        {
            var newabout = new Apply
            {
                 Email = email,
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phoneNumber,
                Description = desc,
                CreatedOn = createdOn
            };

            await this._repo.InsertAsync(newabout).ConfigureAwait(true);

            return newabout;
        }

        public async Task<Apply> Update(string email, string desc, string firstName, string lastName, string phoneNumber, DateTime createdOn)
        {
            var newabout = new Apply
            {
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phoneNumber,
                Description = desc,
                CreatedOn = createdOn
            };

            await this._repo.UpdateAsync(newabout).ConfigureAwait(true);

            return newabout;
        }

        public async Task<Apply> Delete(string email, string desc, string firstName, string lastName, string phoneNumber, DateTime createdOn)
        {
            var newabout = new Apply
            {
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phoneNumber,
                Description = desc,
                CreatedOn = createdOn
            };

            await this._repo.DeleteAsync(newabout).ConfigureAwait(true);

            return newabout;
        }
    }
}
