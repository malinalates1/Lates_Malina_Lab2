using Lates_Malina_Lab2.Models;
using System.Collections.Generic;

namespace Lates_Malina_Lab2.ViewModels
{
    public class PublisherIndexData
    {
        public IEnumerable<Publisher> Publishers { get; set; } = new List<Publisher>();
        public IEnumerable<Book> Books { get; set; } = new List<Book>();
    }
}
