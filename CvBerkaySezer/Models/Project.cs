using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CvBerkaySezer.Models
{
    public class Project
    {
        public int Id { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50, ErrorMessage = "En fazla 50 karakter girebilirsiniz")]
        [Required(ErrorMessage = "Başlık alanı boş geçilemez")]
        public string Title { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50, ErrorMessage = "En fazla 50 karakter girebilirsiniz")]
        [Required(ErrorMessage = "Etiket alanı boş geçilemez")]
        public string Tag { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(256)]
        [Required(ErrorMessage = "Görsel alanı boş geçilemez")]
        public string ImageUrl { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(256)]
        public string ProjectUrl { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}