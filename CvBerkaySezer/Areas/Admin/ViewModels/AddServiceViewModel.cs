using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CvBerkaySezer.Areas.Admin.ViewModels
{
    public class AddServiceViewModel
    {
        [StringLength(50, ErrorMessage = "En fazla 50 karakter girebilirsiniz")]
        [Required(ErrorMessage = "Başlık alanı boş geçilemez")]
        public string AddTitle { get; set; }

        [StringLength(500, ErrorMessage = "En fazla 500 karakter girebilirsiniz")]
        [Required(ErrorMessage = "Açıklama alanı boş geçilemez")]
        public string AddDefinition { get; set; }
        public string AddImageUrl { get; set; }

    }
}