using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CvBerkaySezer.Models
{
    public class Service
    {
        public int Id { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50, ErrorMessage = "En fazla 50 karakter girebilirsiniz")]
        [Required(ErrorMessage = "Başlık alanı boş geçilemez")]
        public string Title { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(200, ErrorMessage = "En fazla 50 karakter girebilirsiniz")]
        [Required(ErrorMessage = "Açıklama alanı boş geçilemez")]
        public string Definition { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(256)]
        [Required(ErrorMessage = "Görsel alanı boş geçilemez")]
        public string ImageUrl { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}