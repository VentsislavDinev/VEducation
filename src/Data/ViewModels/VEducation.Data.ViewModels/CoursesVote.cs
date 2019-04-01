namespace VAgency.Data.ViewModels.Models.Blog
{
    public class CoursesVoteViewModel
    {
        public int Id { get; set; }

        public bool IsVote { get; set; }

        public string User { get; set; }

        public string BlogPost { get; set; }
    }
}