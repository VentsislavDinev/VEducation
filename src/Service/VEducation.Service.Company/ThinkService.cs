using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEducation.Data.Model;

namespace VEducation.Service.Company
{
    public class ThinkService : CompanyServiceBase, IThinkService
    {
        /// <summary>
        /// The repo
        /// </summary>
        private readonly IRepository<Think> _repo;


        public ThinkService(IRepository<Think> repo)
        {
            if (repo == null)
            {
                throw new ArgumentNullException("repo is null or empty");
            }

            _repo = repo;
        }


        public async Task<Think> Create(string title, string desc)
        {
            var newabout = new Think
            {
               Title = title, 
               Description = desc
            };

            await this._repo.InsertAsync(newabout).ConfigureAwait(true);

            return newabout;
        }

        public async Task<Think> Update(string title, string desc)
        {
            var newabout = new Think
            {
                Title = title,
                Description = desc
            };

            await this._repo.UpdateAsync(newabout).ConfigureAwait(true);

            return newabout;
        }

        public async Task<Think> Delete(string title, string desc)
        {
            var newabout = new Think
            {
                Title = title,
                Description = desc
            };

            await this._repo.DeleteAsync(newabout).ConfigureAwait(true);

            return newabout;
        }
    }
}
