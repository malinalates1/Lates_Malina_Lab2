using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lates_Malina_Lab2.Models
{
    public class Author
    {
        public int ID { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        // Relație: un autor poate avea mai multe cărți
        public ICollection<Book>? Books { get; set; }
    }
}
