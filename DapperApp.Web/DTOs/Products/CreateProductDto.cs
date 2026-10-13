using System.ComponentModel.DataAnnotations;

public class CreateProductDto
{
    [Required(ErrorMessage = "Ürün adı zorunludur.")]
    [StringLength(50, ErrorMessage = "En fazla 50 karakter giriniz.")]
    public string Name { get; set; } = string.Empty;

    [Range(0, 999999999, ErrorMessage = "Fiyat negatif olamaz.")]
    public decimal Price { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Stok negatif olamaz.")]
    public int Stock { get; set; }

    public string? ImageUrl { get; set; }

    public bool IsActive { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Kategori seçiniz.")]
    public int CategoryId { get; set; }
}