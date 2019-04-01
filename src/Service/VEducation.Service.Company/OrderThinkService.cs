using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using VEducation.Data.Model;
using VEducation.Data.ViewModels;

namespace VEducation.Service.Company
{
    public class OrderThinkService : IOrderThinkService
    {
        /// <summary>
        /// The repo
        /// </summary>
        private readonly IRepository<Think> _repo;


        public OrderThinkService(IRepository<Think> repo)
        {
            if (repo == null)
            {
                throw new ArgumentNullException("repo is null or empty");
            }

            _repo = repo;
        }

        public List<ThinkViewModel> GetLast()
        {
            return _repo.GetAll()
                .Select(x => new ThinkViewModel
                {
                     Description = x.Description,
                     Title = x.Title,
                })
                .ToList();
        }
    }
}
