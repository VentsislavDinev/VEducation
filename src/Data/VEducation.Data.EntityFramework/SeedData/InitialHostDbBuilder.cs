using EntityFramework.DynamicFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VEducation.Data.EntityFramework.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly EducationDbContext _context;

        public InitialHostDbBuilder(EducationDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            //new DefaultSettingsCreator(_context).Create();
        }
    }
}
