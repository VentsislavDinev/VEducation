using System;
using System.ComponentModel.DataAnnotations;

namespace VAgency.Data.ViewModels.Company
{
    public class CompanyMessageCreateViewModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreationTime { get; set; }

        public string Phone { get; set; }

        public string FirstName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string LastName { get; set; }
    }
}