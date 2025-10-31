using Microsoft.AspNetCore.Mvc.RazorPages;
using Lates_Malina_Lab2.Data;
using Lates_Malina_Lab2.Models;

namespace Lates_Malina_Lab2.Pages.Books
{
    public class BookCategoriesPageModel : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList { get; set; } = new List<AssignedCategoryData>();

        protected void PopulateAssignedCategoryData(Lates_Malina_Lab2Context context, Book book)
        {
            var allCategories = context.Category.ToList();
            var bookCategories = new HashSet<int>(book.BookCategories?.Select(c => c.CategoryID) ?? new List<int>());
            AssignedCategoryDataList = allCategories.Select(c => new AssignedCategoryData
            {
                CategoryID = c.ID,
                CategoryName = c.CategoryName,
                Assigned = bookCategories.Contains(c.ID)
            }).ToList();
        }

        protected void UpdateBookCategories(Lates_Malina_Lab2Context context, string[] selectedCategories, Book bookToUpdate)
        {
            if (selectedCategories == null)
            {
                bookToUpdate.BookCategories = new List<BookCategory>();
                return;
            }

            var selectedHS = new HashSet<string>(selectedCategories);
            var bookCategories = new HashSet<int>(bookToUpdate.BookCategories?.Select(c => c.CategoryID) ?? new List<int>());

            foreach (var cat in context.Category)
            {
                if (selectedHS.Contains(cat.ID.ToString()))
                {
                    if (!bookCategories.Contains(cat.ID))
                        bookToUpdate.BookCategories.Add(new BookCategory { BookID = bookToUpdate.ID, CategoryID = cat.ID });
                }
                else
                {
                    if (bookCategories.Contains(cat.ID))
                    {
                        var toRemove = bookToUpdate.BookCategories.FirstOrDefault(c => c.CategoryID == cat.ID);
                        if (toRemove != null)
                            bookToUpdate.BookCategories.Remove(toRemove);
                    }
                }
            }
        }
    }
}
