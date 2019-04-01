using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEducation.Data.Model;

namespace VEducation.Service.Company
{
    public class GalleryService : CompanyServiceBase, IGalleryService
    {
        /// <summary>
        /// The repo
        /// </summary>
        private readonly IRepository<Gallery> _repo;


        public GalleryService(IRepository<Gallery> repo)
        {
            if (repo == null)
            {
                throw new ArgumentNullException("repo is null or empty");
            }

            _repo = repo;
        }


        public async Task<Gallery> Create(string title)
        {
            var newabout = new Gallery
            {
                 FilePath = title,
            };

            await this._repo.InsertAsync(newabout).ConfigureAwait(true);

            return newabout;
        }

        public async Task<Gallery> Update(string title)
        {
            var newabout = new Gallery
            {
                FilePath = title,
            };

            await this._repo.UpdateAsync(newabout).ConfigureAwait(true);

            return newabout;
        }

        public async Task<Gallery> Delete(string title)
        {
            var newabout = new Gallery
            {
                FilePath = title,
            };

            await this._repo.DeleteAsync(newabout).ConfigureAwait(true);

            return newabout;
        }
    }
}
