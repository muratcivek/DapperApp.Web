using System.ComponentModel.DataAnnotations;

namespace DapperApp.Web.DTOs.Categories
{
    public class CreateCategoryDto
    {

        [Required(ErrorMessage = "Kategori adı zorunludur.")]
        [StringLength(50, ErrorMessage = "Kategori adı en fazla 50 karakter olabilir.")]
        [Display(Name = "Kategori Adı")]
        public string Name { get; set; } = string.Empty;
    }
}
