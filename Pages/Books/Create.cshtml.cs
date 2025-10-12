using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Lates_Malina_Lab2.Data;
using Nume_Pren_Lab2.Models;

namespace Lates_Malina_Lab2.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly Lates_Malina_Lab2.Data.Lates_Malina_Lab2Context _context;

        public CreateModel(Lates_Malina_Lab2.Data.Lates_Malina_Lab2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            // Populăm dropdown-ul pentru Publisher
            ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID", "PublisherName");

            // Populăm dropdown-ul pentru Author (afișăm nume complet)
            ViewData["AuthorID"] = new SelectList(
                _context.Set<Author>().Select(a => new { a.ID, FullName = a.FirstName + " " + a.LastName }),
                "ID",
                "FullName"
            );

            return Page();
        }

        [BindProperty]
        public Book Book { get; set; } = default!;

        // Post pentru salvare
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Book.Add(Book);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
