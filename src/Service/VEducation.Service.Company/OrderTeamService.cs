using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEducation.Data.Model;
using VEducation.Data.ViewModels;

namespace VEducation.Service.Company
{
    public class OrderTeamService : IOrderTeamService
    {

        /// <summary>
        /// The repo
        /// </summary>
        private readonly IRepository<Team> _repo;


        public OrderTeamService(IRepository<Team> repo)
        {
            if (repo == null)
            {
                throw new ArgumentNullException("repo is null or empty");
            }

            _repo = repo;
        }

        public List<TeamViewModel> GetAll()
        {
            return _repo.GetAll().Select(x => new TeamViewModel
            {
                 Description = x.Description, 
                 FilePath = x.FilePath,
                 FirstName = x.FirstName,
                 LastName = x.LastName,
                  Position = x.Position,
            })
            .ToList();
        }
    }
}
