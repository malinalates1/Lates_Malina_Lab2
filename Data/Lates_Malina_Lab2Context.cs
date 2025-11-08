using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lates_Malina_Lab2.Models;
using Lates_Malina_Lab2.Models;

namespace Lates_Malina_Lab2.Data
{
    public class Lates_Malina_Lab2Context : DbContext
    {
        public Lates_Malina_Lab2Context (DbContextOptions<Lates_Malina_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Lates_Malina_Lab2.Models.Book> Book { get; set; } = default!;
        public DbSet<Publisher> Publisher { get; set; } = default!;
        public DbSet<Author> Authors { get; set; } = default!;
        public DbSet<Lates_Malina_Lab2.Models.Category> Category { get; set; } = default!;
        public DbSet<Lates_Malina_Lab2.Models.Member> Member { get; set; } = default!;
        public DbSet<Lates_Malina_Lab2.Models.Borrowing> Borrowing { get; set; } = default!;

    }
}
