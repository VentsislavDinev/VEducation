using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VEducation.Data.ViewModels
{
    public class ApplyViewModel
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }

        //public int MaxPage { get; set; }
        //public int PreviosPage { get; set; }
        public IEnumerable<ApplySingleViewModel> ApplySingle { get; set; }

    }
}
