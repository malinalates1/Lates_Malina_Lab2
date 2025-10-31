using System.Collections.Generic;
using Lates_Malina_Lab2.Models;

namespace Lates_Malina_Lab2.ViewModels
{
    public class CategoryIndexData
    {
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
        public IEnumerable<Book> Books { get; set; } = new List<Book>();
    }
}
