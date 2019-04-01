namespace VEducation.Service.Company
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Abp.Domain.Repositories;
    
    using Education.Service.Company;
    using VEducation.Data.Model;

    /// <summary>
    /// The contact.
    /// </summary>
    public class Contact : CompanyServiceBase, IContact
    {
        /// <summary>
        /// The repo
        /// </summary>
        private IRepository<CompanyContact> _repo;

        /// <summary>
        /// Initializes a new instance of the <see cref="Contact"/> class.
        /// </summary>
        /// <param name="repo">
        /// The repo.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        public Contact(IRepository<CompanyContact> repo)
        {
            if (repo == null)
            {
                throw new ArgumentNullException("repo is null or empty");
            }
            this._repo = repo;
        }

        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<CompanyContact> GetAll()
        {
            var getAllContact = this._repo.GetAll();
            return getAllContact;
        }

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="office">
        /// The office.
        /// </param>
        /// <param name="number">
        /// The number.
        /// </param>
        /// <param name="workFrom">
        /// The work from.
        /// </param>
        /// <param name="workTo">
        /// The work to.
        /// </param>
        /// <param name="createdOn">
        /// The created on.
        /// </param>
        /// <param name="address">
        /// The address.
        /// </param>
        /// <param name="city">
        /// The city.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public async Task<CompanyContact> Create(string office, string number, DateTime workFrom, DateTime workTo, DateTime createdOn, string address, string city)
        {
            var newContact = new CompanyContact
            {
                OfficeCountry = office,
                Phonenumber = number,
                WorkFrom = workFrom,
                WorkTo = workTo,
                Address = address,
                City = city,
                CreationTime = createdOn
            };

            await this._repo.InsertAsync(newContact).ConfigureAwait(true);
       
            return newContact;
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
        /// <exception cref="Exception">
        /// </exception>
        public async Task<CompanyContact> Delete(int id, DateTime deletedOn)
        {
            var newContact = new CompanyContact()
            {
                IsDeleted = true,
                DeletedOn = deletedOn,
            };
           
            await this._repo.UpdateAsync(newContact).ConfigureAwait(true);
            
            return newContact;
        }
        
        public async Task<CompanyContact> Update(int id, string office, string number, DateTime workFrom, DateTime workTo, DateTime createdOn, string address, string city)
        {
            var newContact = new CompanyContact
            {
                DeletedOn = createdOn,
                IsDeleted = true,
                OfficeCountry = office,
                Phonenumber = number,
                WorkFrom = workFrom,
                WorkTo = workTo,
                Address = address,
                City = city,
                PreserveCreatedOn = true,
            };

            await this._repo.DeleteAsync(newContact).ConfigureAwait(true);
           
            return newContact;
        }
    }
}
