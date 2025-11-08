using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lates_Malina_Lab2.Data;
using Lates_Malina_Lab2.Models;

namespace Lates_Malina_Lab2.Pages.Borrowings
{
    public class DetailsModel : PageModel
    {
        private readonly Lates_Malina_Lab2.Data.Lates_Malina_Lab2Context _context;

        public DetailsModel(Lates_Malina_Lab2.Data.Lates_Malina_Lab2Context context)
        {
            _context = context;
        }

        public Borrowing Borrowing { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Borrowing = await _context.Borrowing
                .Include(b => b.Book)
                    .ThenInclude(b => b.Author)
                .Include(b => b.Member)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Borrowing == null)
            {
                return NotFound();
            }

            return Page();
        }

    }
}
