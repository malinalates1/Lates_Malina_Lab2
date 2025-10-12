using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nume_Pren_Lab2.Models
{
    public class Book
    {
        public int ID { get; set; }

        [Display(Name = "Book Title")]
        public string Title { get; set; }

        // Foreign Key pentru Author
        public int? AuthorID { get; set; }

        // Navigation property pentru Author
        public Author? Author { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublishingDate { get; set; }

        // Publisher
        public int? PublisherID { get; set; }
        public Publisher? Publisher { get; set; }
    }
}
