using Abp.Domain.Entities;

namespace VEducation.Data.Model
{
    public class Feature : Entity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
