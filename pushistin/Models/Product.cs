using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace pushistin.Models {

    public class Product {

        public long ProductID { get; set; }

        [Required(ErrorMessage = "Введите название")]
        public string? Name { get; set; } = String.Empty;

        [Required(ErrorMessage = "Введите бренд")]
        public string? Brand { get; set; } = String.Empty;

        [Required(ErrorMessage = "Введите описание")]
        public string? Description { get; set; } = String.Empty;

        [Required(ErrorMessage = "Введите тип питомца")]
        public string? Pet { get; set; } = String.Empty;

        [Required(ErrorMessage = "Введите категорию")]
        public string? Category { get; set; } = String.Empty;

        public string? Weight { get; set; } = String.Empty;

        [Required]
        [Range(0.01, double.MaxValue,
            ErrorMessage = "Введите цену")]
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Price { get; set; }
        [NotMapped]
        [Range(0.01, double.MaxValue)]
        [Column(TypeName = "decimal(8, 2)")]
        public decimal? DiscountPrice { get; set; }
        public byte[]? ByteImage { get; set; }
        [Required]
        public bool IsStock { get; set; }
    }
}
