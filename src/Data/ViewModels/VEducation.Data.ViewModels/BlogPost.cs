namespace VAgency.Data.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web;
    using System.Web.Mvc;

    public class BlogPostVieModel
    {
        public int? Id { get; set; }

        [DataType(DataType.Text)]
        public string Title { get; set; }

        [AllowHtml]
        [Display(Name = "Content")]
        [DataType("tinymce_full")]
        [UIHint("tinymce_full")]
        [StringLength(2000, MinimumLength = 3, ErrorMessage = "полето  трябва да е между 3 и 2000 символа")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        public string ShortContent { get; set; }
        public HttpPostedFileBase Upload { get; set; }

        public string UserId { get; set; }

        public DateTime CreationTime { get; set; }
        public int CategoryId { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; } 
      
        public string Category { get; set; }
    }
}