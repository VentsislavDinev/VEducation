using System;
using System.Threading.Tasks;
using VEducation.Data.Model;

namespace VEducation.Service.Company
{
    public interface IApplyService
    {
        Task<Apply> Create(string email, string desc, string firstName, string lastName, string phoneNumber, DateTime createdOn);
        Task<Apply> Delete(string email, string desc, string firstName, string lastName, string phoneNumber, DateTime createdOn);
        Task<Apply> Update(string email, string desc, string firstName, string lastName, string phoneNumber, DateTime createdOn);
    }
}