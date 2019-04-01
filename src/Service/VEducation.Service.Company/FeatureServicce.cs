using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEducation.Data.Model;

namespace VEducation.Service.Company
{
    public class FeatureServicce : CompanyServiceBase, IFeatureServicce
    {
        /// <summary>
        /// The repo
        /// </summary>
        private IRepository<Feature> _repo;


        public FeatureServicce(IRepository<Feature> repo)
        {
            if (repo == null)
            {
                throw new ArgumentNullException("repo is null or empty");
            }

            this._repo = repo;
        }
        public async Task<Feature> Create(string name, string desc)
        {
            var newabout = new Feature
            {
                Title = name,
                Description = desc
            };

            await this._repo.InsertAsync(newabout).ConfigureAwait(true);

            return newabout;
        }

        public async Task<Feature> Update(string name, string desc)
        {
            var newabout = new Feature
            {
                Title = name,
                Description = desc
            };

            await this._repo.UpdateAsync(newabout).ConfigureAwait(true);

            return newabout;
        }

        public async Task<Feature> Delete(string name, string desc)
        {
            var newabout = new Feature
            {
                Title = name,
                Description = desc
            };

            await this._repo.DeleteAsync(newabout).ConfigureAwait(true);

            return newabout;
        }
    }
}
