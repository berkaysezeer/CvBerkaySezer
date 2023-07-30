using CvBerkaySezer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CvBerkaySezer.Areas.Admin.ViewModels
{

    public class AddSkillViewModel
    {
        [StringLength(50, ErrorMessage = "En fazla 50 karakter girebilirsiniz")]
        [Required(ErrorMessage = "Başlık alanı boş geçilemez")]
        public string AddTitle { get; set; }
        public int AddRate { get; set; }
    }
}