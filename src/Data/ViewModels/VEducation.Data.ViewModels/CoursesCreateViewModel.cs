using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;


namespace VAgency.Data.ViewModels.Blog
{
    public class CoursesCreateViewModel
    {
        public string Title { get; set; }

       [AllowHtml]
        [DataType("tinymce_full")]
        [UIHint("tinymce_full")]
        public string Description { get; set; }

        public int CategoryId { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }
        public DateTime CreationTime { get; set; }

        public string ShortContent { get; set; }

        public HttpPostedFileBase Upload { get; set; }
        public int Id { get; set; }
    }
}