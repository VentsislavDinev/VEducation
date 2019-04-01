﻿namespace VAgency.Data.ViewModels.Company
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CompanyMessageViewModel
    {
        public CompanyMessageViewModel()
        {
        }

        public int Id { get; set; }

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