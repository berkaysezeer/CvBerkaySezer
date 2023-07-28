using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CvBerkaySezer.Models
{
    public class User
    {
        [Key]
        [Column(TypeName = "Varchar")]
        [StringLength(15, ErrorMessage = "En fazla 15 karakter girebilirsiniz")]
        [Required(ErrorMessage = "Kullanıcı adı alanı boş geçilemez")]
        public string UserName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50, ErrorMessage = "En fazla 50 karakter girebilirsiniz")]
        [Required(ErrorMessage = "Şifre alanı boş geçilemez")]
        public string Password { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter girebilirsiniz")]
        [Required(ErrorMessage = "Ad Soyad alanı boş geçilemez")]
        public string FullName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(15, ErrorMessage = "En fazla 15 karakter girebilirsiniz")]
        [Required(ErrorMessage = "Ad Soyad alanı boş geçilemez")]
        public string Role { get; set; }
    }
}