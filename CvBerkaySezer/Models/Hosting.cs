using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CvBerkaySezer.Models
{
    public class Hosting
    {
        public int Id { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50, ErrorMessage = "En fazla 50 karakter girebilirsiniz")]
        [Required(ErrorMessage = "Başlık alanı boş geçilemez")]
        public string Title { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(256, ErrorMessage = "En fazla 256 karakter girebilirsiniz")]
        [Required(ErrorMessage = "Açıklama alanı boş geçilemez")]
        public string Description { get; set; }

        public bool IsDeleted { get; set; } = false;
        public bool IsActive { get; set; } = true;

        [Required(ErrorMessage = "Tutar alanı boş geçilemez")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Kayıt Tarihi alanı boş geçilemez")]
        public DateTime RegistrationDate { get; set; }

        [Required(ErrorMessage = "Sonraki Ödeme Tarihi alanı boş geçilemez")]
        public DateTime NextPaymentDate { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50, ErrorMessage = "En fazla 50 karakter girebilirsiniz")]
        public string UserName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100, ErrorMessage = "En fazla 100 karakter girebilirsiniz")]
        public string HostUrl { get; set; }

        public virtual Client Client { get; set; }
        public int ClientId { get; set; }

        public virtual ServiceProvider ServiceProvider { get; set; }
        public int ServiceProviderId { get; set; }
    }
}