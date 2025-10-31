using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lates_Malina_Lab2.Data;
using Lates_Malina_Lab2.Models;
using Lates_Malina_Lab2.ViewModels;

namespace Lates_Malina_Lab2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Lates_Malina_Lab2Context _context;

        public IndexModel(Lates_Malina_Lab2Context context)
        {
            _context = context;
        }

        public IList<Category> Category { get; set; } = default!;
        public CategoryIndexData CategoryData { get; set; }
        public int CategoryID { get; set; }

        public async Task OnGetAsync(int? id)
        {
            CategoryData = new CategoryIndexData();

            // aduce toate categoriile, fiecare cu cărțile asociate
            CategoryData.Categories = await _context.Category
                .Include(c => c.BookCategories)
                    .ThenInclude(bc => bc.Book)
                        .ThenInclude(b => b.Author)
                .OrderBy(c => c.CategoryName)
                .ToListAsync();

            // dacă utilizatorul a selectat o categorie (prin link)
            if (id != null)
            {
                CategoryID = id.Value;
                Category category = CategoryData.Categories
                    .Where(c => c.ID == id.Value)
                    .Single();

                // cărțile din categoria selectată
                CategoryData.Books = category.BookCategories.Select(bc => bc.Book);
            }
        }
    }
}
