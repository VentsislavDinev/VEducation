namespace VEducation.Service.Company
{
    using Abp.Domain.Repositories;
    using Education.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Education.Service.Company;
    using Education.Service.User.Company;

    /// <summary>
    /// The company logo service.
    /// </summary>
    public class CompanyLogoService : CompanyServiceBase, ICompanyLogoService
    {
        /// <summary>
        /// The repo
        /// </summary>
        private IRepository<CompanyLogo> _repo;

        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyLogoService"/> class.
        /// </summary>
        /// <param name="repo">
        /// The repo.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        public CompanyLogoService(IRepository<CompanyLogo> repo)
        {
            if (repo == null)
            {
                throw new ArgumentNullException("repo is null or empty");
            }

            _repo = repo;
        }

        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<CompanyLogo> GetAll()
        {
            IQueryable<CompanyLogo> getAll = _repo.GetAll();
            return getAll;
        }

        /// <summary>
        /// The get by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<CompanyLogo> GetById(int id)
        {
            IQueryable<CompanyLogo> getById = _repo.GetAll().Where(x => x.Id == id);
            return getById;
        }

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="filePath">
        /// The file path.
        /// </param>
        /// <param name="fileType">
        /// The file type.
        /// </param>
        /// <param name="title">
        /// The title.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<CompanyLogo> Create(string filePath, FileType fileType, string title)
        {
            CompanyLogo avatar = new CompanyLogo
            {
                FileName = filePath,
                FileType = fileType,
                Title = title
            };
            await _repo.InsertAsync(avatar).ConfigureAwait(true);

            return avatar;
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="filePath">
        /// The file path.
        /// </param>
        /// <param name="fileType">
        /// The file type.
        /// </param>
        /// <param name="title">
        /// The title.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<CompanyLogo> Update(int id, string filePath, FileType fileType, string title)
        {
            CompanyLogo avatar = new CompanyLogo
            {
                FileName = filePath,
                FileType = fileType,
                Title = title,
            };

            await _repo.UpdateAsync(avatar).ConfigureAwait(true);

            return avatar;
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="deletedOn">
        /// The deleted on.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<CompanyLogo> Delete(int id, DateTime deletedOn)
        {
            CompanyLogo avatar = new CompanyLogo
            {
                DeletedOn = deletedOn,
                IsDeleted = true
            };

            await _repo.DeleteAsync(avatar).ConfigureAwait(true);
            
            return avatar;
        }
    }
}