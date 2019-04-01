using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VEducation.Data.Model
{
    public class Gallery : Entity
    {
        public int Id { get; set; }
        public string FilePath { get; set; }
    }
}
