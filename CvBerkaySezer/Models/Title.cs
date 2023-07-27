using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CvBerkaySezer.Models
{
    public class Title
    {
        public int Id { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100, ErrorMessage = "En fazla 15 karakter girebilirsiniz")]
        [Required(ErrorMessage = "Başlık alanı boş geçilemez")]
        public string Head { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(500, ErrorMessage = "En fazla 256 karakter girebilirsiniz")]
        [Required(ErrorMessage = "İçerik alanı boş geçilemez")]
        public string Content { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}