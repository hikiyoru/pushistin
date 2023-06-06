using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace pushistin.Models {

    public class Order {

        [BindNever]
        public int OrderID { get; set; }

        [BindNever]
        public string? UserID { get; set; }
        [BindNever]
        public ICollection<CartLine> Lines { get; set; } = new List<CartLine>();

        [Required(ErrorMessage = "Введите имя")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Введите номер телефона")]
        [Phone(ErrorMessage = "Неверный формат телефона")]
        public string? Phone { get; set; }
        [Required(ErrorMessage = "Введите город")]
        public string? City { get; set; }

        [Required(ErrorMessage = "Введите улицу")]
        public string? Street { get; set; }

        [Required(ErrorMessage = "Введите номер дома")]
        public int? Home { get; set; }
        public int? FrontDoor { get; set; }
        public int? Apartment { get; set; }

        [BindNever]
        public string Status { get; set; } = "Обрабатывается";

        public bool? Paid { get; set; }

        [Required(ErrorMessage = "Выберете способ оплаты")]
        public string? PaymentWay { get; set; }

        public decimal Price { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }

        [NotMapped]
        public string? StatusMessage { get; set; }
        public string? OrderNotes { get; set; }

    }
}
