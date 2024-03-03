using System;
using System.ComponentModel.DataAnnotations;

namespace PruebaApi.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El título es obligatorio.")]
        [StringLength(100, ErrorMessage = "El título no puede tener más de 100 caracteres.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "El autor es obligatorio.")]
        [StringLength(50, ErrorMessage = "El nombre del autor no puede tener más de 50 caracteres.")]
        public string Author { get; set; }

        [StringLength(50, ErrorMessage = "El género no puede tener más de 50 caracteres.")]
        public string Genre { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "La fecha de publicación es obligatoria.")]
        public DateTime PublishDate { get; set; }
    }
}
