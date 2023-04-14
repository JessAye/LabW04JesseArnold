using LabW04JesseArnold.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LabW04JesseArnold.Services
{
    
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions options) : base(options) { }
            public DbSet<Book> Books => Set<Book>();
            public DbSet<Author> Authors => Set<Author>();
        }
    }

