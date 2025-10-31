using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lates_Malina_Lab2.Models
{
    public class Author
    {
        public int ID { get; set; }  // Cheia primară

        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;

        // Navigation property: relație 1 autor → multe cărți
        public ICollection<Book>? Books { get; set; }
    }
}
