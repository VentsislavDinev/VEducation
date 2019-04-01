using Abp.Domain.Entities;

namespace VEducation.Data.Model
{
    public class TeamSocialLink : Entity
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }
        public string FaImage { get; set; }
    }
}