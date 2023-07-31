using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CvBerkaySezer.Models
{
    public class ServiceProvider
    {
        public int Id { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20, ErrorMessage = "En fazla 20 karakter girebilirsiniz")]
        [Required(ErrorMessage = "Sağlayıcı Adı alanı boş geçilemez")]
        public string Name { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50, ErrorMessage = "En fazla 50 karakter girebilirsiniz")]
        [Required(ErrorMessage = "Url alanı boş geçilemez")]
        public string Url { get; set; }
        public bool IsDeleted { get; set; } = false;

        public ICollection<Hosting> Hostings { get; set; }
    }
}