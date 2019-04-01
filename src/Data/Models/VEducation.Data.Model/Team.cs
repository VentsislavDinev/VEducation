using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VEducation.Data.Model
{
    public class Team : Entity
    {
        /// <summary>
        /// The blog post answer.
        /// </summary>
        private ICollection<TeamSocialLink> blogPostAnswer;

        public Team()
        {
            this.blogPostAnswer = new HashSet<TeamSocialLink>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FilePath { get; set; }
        public string Description { get; set; }
        public string Position { get; set; }
        /// <summary>
        /// Gets or sets the blog image id.
        /// </summary>
        public int TeamSocialLinkId { get; set; }

        /// <summary>
        /// Gets or sets the blog image.
        /// </summary>
        public virtual ICollection<TeamSocialLink> TeamSocialLink
        {
            get => blogPostAnswer;
            set => blogPostAnswer = value;
        }
    }
}
