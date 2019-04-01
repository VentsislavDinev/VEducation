using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VEducation.Data.ViewModels.Account
{

    public class LoginFormViewModel
    {
        public string ReturnUrl { get; set; }

        public bool IsMultiTenancyEnabled { get; set; }
    }
}
