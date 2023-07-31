using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CvBerkaySezer.Areas.Admin.ViewModels
{
    public class AddClientViewModel
    {
        [StringLength(50, ErrorMessage = "En fazla 50 karakter girebilirsiniz")]
        [Required(ErrorMessage = "Ad Soyad alanı boş geçilemez")]
        public string AddFullName { get; set; }

        [StringLength(17, ErrorMessage = "En fazla 17 karakter girebilirsiniz")]
        [Required(ErrorMessage = "Telefon alanı boş geçilemez")]
        public string AddTelephone { get; set; }

        [StringLength(30, ErrorMessage = "En fazla 30 karakter girebilirsiniz")]
        [Required(ErrorMessage = "E-posta alanı boş geçilemez")]
        public string AddEmail { get; set; }
    }
}