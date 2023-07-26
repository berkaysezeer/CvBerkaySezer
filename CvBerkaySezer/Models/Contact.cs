using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CvBerkaySezer.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50, ErrorMessage = "En fazla 50 karakter girebilirsiniz")]
        [Required(ErrorMessage = "Ad alanı boş geçilemez")]
        public string Name { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50, ErrorMessage = "En fazla 50 karakter girebilirsiniz")]
        [Required(ErrorMessage = "Soyad alanı boş geçilemez")]
        public string Surname { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(1056, ErrorMessage = "En fazla 1056 karakter girebilirsiniz")]
        [Required(ErrorMessage = "Mesaj alanı boş geçilemez")]
        public string Message { get; set; }
        public DateTime Time { get; set; }
        public bool IsRead { get; set; } = false;
    }
}