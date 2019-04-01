using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEducation.Data.Model;

namespace VEducation.Service.Company
{
    public class TeamSocialLinkService : ITeamSocialLinkService
    {
        /// <summary>
        /// The repo
        /// </summary>
        private readonly IRepository<TeamSocialLink> _repo;


        public TeamSocialLinkService(IRepository<TeamSocialLink> repo)
        {
            if (repo == null)
            {
                throw new ArgumentNullException("repo is null or empty");
            }

            _repo = repo;
        }


        public async Task<TeamSocialLink> Create(int teamId, string filePath, string url)
        {
            var newabout = new TeamSocialLink
            {
               FaImage = filePath,
                Url = url,
                TeamId = teamId
            };

            await this._repo.InsertAsync(newabout).ConfigureAwait(true);

            return newabout;
        }


        public async Task<TeamSocialLink> Update(int teamId, string filePath, string url)
        {
            var newabout = new TeamSocialLink
            {
                FaImage = filePath,
                Url = url,
                TeamId = teamId
            };

            await this._repo.UpdateAsync(newabout).ConfigureAwait(true);

            return newabout;
        }


        public async Task<TeamSocialLink> Delete(int teamId, string filePath, string url)
        {
            var newabout = new TeamSocialLink
            {
                FaImage = filePath,
                Url = url,
                TeamId = teamId
            };

            await this._repo.DeleteAsync(newabout).ConfigureAwait(true);

            return newabout;
        }

    }
}
