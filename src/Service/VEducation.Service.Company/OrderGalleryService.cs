using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using VEducation.Data.Model;
using VEducation.Data.ViewModels;

namespace VEducation.Service.Company
{
    public class OrderGalleryService : CompanyServiceBase, IOrderGalleryService
    {
        /// <summary>
        /// The repo
        /// </summary>
        private readonly IRepository<Gallery> _repo;


        public OrderGalleryService(IRepository<Gallery> repo)
        {
            if (repo == null)
            {
                throw new ArgumentNullException("repo is null or empty");
            }

            _repo = repo;
        }

        public List<GalleryViewModel> GetAll()
        {
            return _repo.GetAll()
                 .Select(x => new GalleryViewModel
                 {
                     FilePath = x.FilePath,
                 })
                 .ToList();
        }
    }
}
