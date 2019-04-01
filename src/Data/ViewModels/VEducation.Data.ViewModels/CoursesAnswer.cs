namespace VAgency.Data.ViewModels
{
    using System;

    public class CoursesAnswerVieModel
    {
        public CoursesAnswerVieModel()
        {
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreationTime { get; set; }

        public string UserId { get; set; }

        public string User { get; set; }

        public int BlogPostsId { get; set; }
    }
}