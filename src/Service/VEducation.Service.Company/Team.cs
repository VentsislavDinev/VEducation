using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEducation.Data.Model;

namespace VEducation.Service.Company
{
    public class TeamService : CompanyServiceBase, ITeamService
    {
        /// <summary>
        /// The repo
        /// </summary>
        private readonly IRepository<Team> _repo;


        public TeamService(IRepository<Team> repo)
        {
            if (repo == null)
            {
                throw new ArgumentNullException("repo is null or empty");
            }

            _repo = repo;
        }


        public async Task<Team> Create(string title, string filePath, string position , string firstName, string lastName, string desc)
        {
            var newabout = new Team
            {
                FilePath = filePath,
                Position = position, 
                LastName = lastName,
                FirstName = firstName,
                Description = desc
            };

            await this._repo.InsertAsync(newabout).ConfigureAwait(true);

            return newabout;
        }

        public async Task<Team> Update(string title, string filePath, string position, string firstName, string lastName, string desc)
        {
            var newabout = new Team
            {
                FilePath = filePath,
                Position = position,
                LastName = lastName,
                FirstName = firstName,
                Description = desc
            };

            await this._repo.UpdateAsync(newabout).ConfigureAwait(true);

            return newabout;
        }

        public async Task<Team> Delete(string title, string filePath, string position, string firstName, string lastName, string desc)
        {
            var newabout = new Team
            {
                FilePath = filePath,
                Position = position,
                LastName = lastName,
                FirstName = firstName,
                Description = desc
            };

            await this._repo.DeleteAsync(newabout).ConfigureAwait(true);

            return newabout;
        }
    }
}
