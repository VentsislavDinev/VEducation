using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Navigation;

namespace VEducation.Data.ViewModels.Layout
{
    public class SocialMenuViewModel
    {
        public IReadOnlyList<UserMenu> SocialMenu { get; set; }
    }
}
