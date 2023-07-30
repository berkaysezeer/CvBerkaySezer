using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CvBerkaySezer.Areas.Admin.ViewModels
{
    public class AddProjectViewModel
    {
        [StringLength(50, ErrorMessage = "En fazla 50 karakter girebilirsiniz")]
        [Required(ErrorMessage = "Başlık alanı boş geçilemez")]
        public string AddTitle { get; set; }

        [StringLength(40, ErrorMessage = "En fazla 100 karakter girebilirsiniz")]
        [Required(ErrorMessage = "Etiket alanı boş geçilemez")]
        public string AddTag { get; set; }
        public string AddImageUrl { get; set; }

        [StringLength(256, ErrorMessage = "En fazla 256 karakter girebilirsiniz")]
        [Required(ErrorMessage = "Url alanı boş geçilemez")]
        public string AddProjectUrl { get; set; }
    }
}