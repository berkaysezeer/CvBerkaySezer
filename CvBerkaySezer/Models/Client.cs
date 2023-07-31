using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CvBerkaySezer.Models
{
    public class Client
    {
        public int Id { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50, ErrorMessage = "En fazla 50 karakter girebilirsiniz")]
        [Required(ErrorMessage = "Ad Soyad alanı boş geçilemez")]
        public string FullName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(17, ErrorMessage = "En fazla 17 karakter girebilirsiniz")]
        [Required(ErrorMessage = "Telefon alanı boş geçilemez")]
        public string Telephone { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter girebilirsiniz")]
        [Required(ErrorMessage = "E-posta alanı boş geçilemez")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Oluşturulma Tarihi alanı boş geçilemez")]
        public DateTime CreatedDate { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}