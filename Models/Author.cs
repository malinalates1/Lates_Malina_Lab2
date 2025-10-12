using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Nume_Pren_Lab2.Models
{
    public class Author
    {
        public int ID { get; set; }  // Cheia primară

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        // Navigation property: relație 1 autor → multe cărți
        public ICollection<Book>? Books { get; set; }
    }
}
