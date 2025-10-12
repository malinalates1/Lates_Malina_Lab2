using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nume_Pren_Lab2.Models;

namespace Lates_Malina_Lab2.Data
{
    public class Lates_Malina_Lab2Context : DbContext
    {
        public Lates_Malina_Lab2Context (DbContextOptions<Lates_Malina_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Nume_Pren_Lab2.Models.Book> Book { get; set; } = default!;
        public DbSet<Publisher> Publisher { get; set; } = default!;
    }
}
