using System;
using System.ComponentModel.DataAnnotations;

namespace PruebaApi.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(50)]
        public string Author { get; set; }

        [StringLength(50)]
        public string Genre { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }
    }
}
