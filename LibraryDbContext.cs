
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace LibrarySystem
{
    public class LibraryDbContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Borrower> Borrowers { get; set; }
        public DbSet<Loan> Loans { get; set; }

        protected override void OnConfiguring(
    DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=DESKTOP-VCB1UKT\SQLEXPRESS;Database=LibrarySystemDB;Trusted_Connection=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Composite Primary Key
            modelBuilder.Entity<Loan>()
                .HasKey(x => new { x.BookId, x.BorrowerId });

            // One Author has many Books
            modelBuilder.Entity<Book>()
                .HasOne(x => x.Author)
                .WithMany(x => x.Books)
                .HasForeignKey(x => x.AuthorId);

            // One Book has many Loans
            modelBuilder.Entity<Loan>()
                .HasOne(x => x.Book)
                .WithMany(x => x.Loans)
                .HasForeignKey(x => x.BookId);

            // One Borrower has many Loans
            modelBuilder.Entity<Loan>()
                .HasOne(x => x.Borrower)
                .WithMany(x => x.Loans)
                .HasForeignKey(x => x.BorrowerId);
        }
    }
}
