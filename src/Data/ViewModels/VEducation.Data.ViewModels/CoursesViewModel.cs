namespace VAgency.Data.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web;
    using System.Web.Mvc;

    public class CoursesPostVieModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "полето е задължително")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "полето  трябва да е между 3 и 20 символа")]
        [DataType(DataType.Text)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        [AllowHtml]
        [Display(Name = "Content")]
        [DataType("tinymce_full")]
        [UIHint("tinymce_full")]
        [StringLength(2000, MinimumLength = 3, ErrorMessage = "полето  трябва да е между 3 и 2000 символа")]
        public string Description { get; set; }

        public HttpPostedFileBase Upload { get; set; }
        [Required(ErrorMessage = "Полето е задължително")]
        public string ShortContent { get; set; }

        public String Image { get; set; }

        public string UserId { get; set; }
        public int CategoryId { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
        [DisplayFormat(DataFormatString = "HH/MM")]
        public DateTime CreationTime { get; set; }
        public string Category { get; set; }
    }
}