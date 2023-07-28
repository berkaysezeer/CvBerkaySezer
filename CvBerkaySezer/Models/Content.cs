using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CvBerkaySezer.Models
{
    public class Content
    {
        public int Id { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(15, ErrorMessage = "En fazla 15 karakter girebilirsiniz")]
        [Required(ErrorMessage = "Ad Soyad alanı boş geçilemez")]
        public string Fullname { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50, ErrorMessage = "En fazla 50 karakter girebilirsiniz")]
        [Required(ErrorMessage = "Başlık alanı boş geçilemez")]
        public string Title { get; set; }

        [AllowHtml]
        [Column(TypeName = "Varchar")]
        [StringLength(2000, ErrorMessage = "En fazla 1024 karakter girebilirsiniz")]
        [Required(ErrorMessage = "İçerik alanı boş geçilemez")]
        public string ContentParagrap { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(256)]
        public string ImageUrl { get; set; }
    }
}