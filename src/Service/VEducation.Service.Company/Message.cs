namespace VEducation.Service.Company
{
    using Abp.Domain.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Education.Service.Company;
    using Education.Data.Models;

    /// <summary>
    /// The message company.
    /// </summary>
    public class MessageCompany : CompanyServiceBase, IMessageCompany
    {
        /// <summary>
        /// The repo
        /// </summary>
        private IRepository<CompanyMessage> _repo;

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageCompany"/> class.
        /// </summary>
        /// <param name="repo">
        /// The repo.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        public MessageCompany(IRepository<CompanyMessage> repo)
        {
            if (repo == null)
            {
                throw new ArgumentNullException("repo is null or empty");
            }

            _repo = repo;
        }

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="firstName">
        /// The first name.
        /// </param>
        /// <param name="desc">
        /// The desc.
        /// </param>
        /// <param name="lastName">
        /// The last name.
        /// </param>
        /// <param name="phone">
        /// The phone.
        /// </param>
        /// <param name="title">
        /// The title.
        /// </param>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <param name="createdOn">
        /// The created on.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<CompanyMessage> Create(string firstName, string desc, string lastName, string phone, string title, string email, DateTime createdOn)
        {
            CompanyMessage newMessage = new CompanyMessage
            {
                Description = desc,
                FirstName = firstName,
                LastName = lastName,
                Phone = phone,
                Title = title,
                Email = email,
                CreatedOn = createdOn
            };

            await this._repo.InsertAsync(newMessage).ConfigureAwait(true);
            
            return newMessage;
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="firstName">
        /// The first name.
        /// </param>
        /// <param name="desc">
        /// The desc.
        /// </param>
        /// <param name="lastName">
        /// The last name.
        /// </param>
        /// <param name="phone">
        /// The phone.
        /// </param>
        /// <param name="title">
        /// The title.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<CompanyMessage> Update(int id, string firstName, string desc, string lastName, string phone, string title)
        {
            CompanyMessage newMessage = new CompanyMessage
            {
                Description = desc,
                FirstName = firstName,
                LastName = lastName,
                Phone = phone,
                Title = title,
                PreserveCreatedOn = true
            };
         
           await this._repo.UpdateAsync(newMessage).ConfigureAwait(false);
         
            return newMessage;
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="createdOn">
        /// The created on.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<CompanyMessage> Delete(int id, DateTime createdOn)
        {
            CompanyMessage newMessage = new CompanyMessage()
            {
                IsDeleted = true,
                DeletedOn = createdOn,
            };

            await this._repo.InsertAsync(newMessage).ConfigureAwait(true);
           
            return newMessage;
        }

        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<CompanyMessage> GetAll()
        {
            var getAllContact = _repo.GetAll();

            return getAllContact;
        }
    }
}