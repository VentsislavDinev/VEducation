using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VEducation.Data.ViewModels
{
    public class TeamViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FilePath { get; set; }
        public string Description { get; set; }
        public string Position { get; set; }
        public string FaSocialImage { get; set; }
        public string SocialLink { get; set; }
    }
}
