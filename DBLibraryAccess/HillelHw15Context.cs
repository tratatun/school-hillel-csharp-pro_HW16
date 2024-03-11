using System;
using System.Collections.Generic;
using DBLibraryAccess.Model;
using Microsoft.EntityFrameworkCore;

namespace DBLibraryAccess;

public interface ILibraryModelContext
{
    DbSet<Author> Authors { get; set; }
    DbSet<AuthorBook> AuthorBooks { get; set; }
    DbSet<Book> Books { get; set; }
    DbSet<DocumentType> DocumentTypes { get; set; }
    DbSet<PublisherCode> PublisherCodes { get; set; }
    DbSet<User> Users { get; set; }
    DbSet<UserRole> UserRoles { get; set; }
    DbSet<UserBook> UserBooks { get; set; }
    int SaveChanges();
}

public partial class HillelHw15Context : DbContext, ILibraryModelContext
{
    public HillelHw15Context()
    {
        // Database.EnsureDeleted();
        // Database.EnsureCreated();
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<AuthorBook> AuthorBooks { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<DocumentType> DocumentTypes { get; set; }

    public virtual DbSet<PublisherCode> PublisherCodes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    public virtual DbSet<UserBook> UserBooks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=DESKTOP-84M0NOK\\SQLEXPRESS;Initial Catalog=Hillel_HW15_3;Integrated Security=True;Trust Server Certificate=True");
        // optionsBuilder.LogTo(Console.WriteLine);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Author");

            entity.ToTable("Author");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AliasName)
                .HasColumnName("alias_name");
            entity.Property(e => e.DateOfBirth)
                .HasColumnType("date")
                .HasColumnName("date_of_birth");
            entity.Property(e => e.FirstName)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasColumnName("last_name");

            entity.HasData(
                new Author { Id = 1, FirstName = "John", LastName = "Doe", DateOfBirth = new DateTime(1980, 1, 1) },
                new Author { Id = 2, FirstName = "Jane", LastName = "Doe", DateOfBirth = new DateTime(1985, 1, 1) },
                new Author { Id = 3, FirstName = "Taras", LastName = "Shevchenko", DateOfBirth = new DateTime(1990, 1, 1) },
                new Author { Id = 4, FirstName = "Les", LastName = "Poddereviansky", DateOfBirth = new DateTime(1995, 1, 1) },
                new Author { Id = 5, FirstName = "Mikle", LastName = "Shur", DateOfBirth = new DateTime(2000, 1, 1) }
            );
        });

        modelBuilder.Entity<AuthorBook>(entity =>
        {
            entity.HasKey(e => new { e.AuthorId, e.BookId });

            entity.ToTable("AuthorBook");

            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.BookId).HasColumnName("book_id");

            entity.HasOne(d => d.Author).WithMany(a => a.AuthorBooks)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_author");

            entity.HasOne(d => d.Book).WithMany(b => b.AuthorBooks)
                .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_book");

            entity.HasData(
                new AuthorBook { AuthorId = 1, BookId = 1 },
                new AuthorBook { AuthorId = 2, BookId = 1 },
                new AuthorBook { AuthorId = 3, BookId = 2 },
                new AuthorBook { AuthorId = 4, BookId = 3 },
                new AuthorBook { AuthorId = 5, BookId = 4 },
                new AuthorBook { AuthorId = 5, BookId = 5 },
                new AuthorBook { AuthorId = 3, BookId = 6 },
                new AuthorBook { AuthorId = 5, BookId = 7 },
                new AuthorBook { AuthorId = 5, BookId = 8 },
                new AuthorBook { AuthorId = 4, BookId = 9 },
                new AuthorBook { AuthorId = 3, BookId = 10 }
                );
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Book");

            entity.ToTable("Book");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.City)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasColumnName("country");
            entity.Property(e => e.PublicationYear).HasColumnName("publication_year");
            entity.Property(e => e.PublisherCode).HasDefaultValue(2).HasColumnName("publisher_code");
            entity.Property(e => e.Title)
                .HasColumnName("title");
            entity.Property(e => e.IsInLibrary)
                .HasColumnName("is_in_library").HasColumnType("bit").HasDefaultValue(true);

            entity.HasOne(d => d.PublisherCodeNavigation).WithMany(p => p.Books)
                .HasForeignKey(d => d.PublisherCode)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_publisher_code");

            entity.HasData(
                new Book { Id = 1, Title = "Book1", PublisherCode = 1, PublicationYear = 2021, Country = "Ukraine", City = "Kyiv"},
                new Book { Id = 2, Title = "Book2", PublisherCode = 2, PublicationYear = 2020, Country = "Ukraine", City = "Kharkiv", IsInLibrary = false },
                new Book { Id = 3, Title = "Book3", PublisherCode = 3, PublicationYear = 2019, Country = "Ukraine", City = "Lviv" },
                new Book { Id = 4, Title = "Book4", PublisherCode = 3, PublicationYear = 2018, Country = "USA", City = "Odessa" },
                new Book { Id = 5, Title = "Book5", PublisherCode = 2, PublicationYear = 2017, Country = "USA", City = "New York", IsInLibrary = false },
                new Book { Id = 6, Title = "Book6", PublisherCode = 1, PublicationYear = 2016, Country = "USA", City = "Washington" },
                new Book { Id = 7, Title = "Book7", PublisherCode = 1, PublicationYear = 2015, Country = "USA", City = "Los Angeles" },
                new Book { Id = 8, Title = "Book8", PublisherCode = 2, PublicationYear = 2014, Country = "Australia", City = "Canbera", IsInLibrary = false },
                new Book { Id = 9, Title = "Book9", PublisherCode = 3, PublicationYear = 2013, Country = "India", City = "Mumbai" },
                new Book { Id = 10, Title = "Book10", PublisherCode = 3, PublicationYear = 2012, Country = "India", City = "Deli" }
            );
        });

        modelBuilder.Entity<DocumentType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Document");

            entity.ToTable("DocumentType");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Type)
                .HasColumnName("type");

            entity.HasData(
                new DocumentType { Id = 1, Type = "Passport" },
                new DocumentType { Id = 2, Type = "Driver License" },
                new DocumentType { Id = 3, Type = "ID Card" }
            );
        });

        modelBuilder.Entity<PublisherCode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Publishe");

            entity.ToTable("PublisherCode");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasColumnName("code");

            entity.HasData(
                new PublisherCode { Id = 1, Code = "PC1" },
                new PublisherCode { Id = 2, Code = "PC2" },
                new PublisherCode { Id = 3, Code = "PC3" });
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_User");

            entity.ToTable("User");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DocumentNumber)
                .HasColumnName("document_number");
            entity.Property(e => e.DocumentTypeId).HasDefaultValue(1).HasColumnName("document_type_id");
            entity.Property(e => e.Email)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasColumnName("last_name");
            entity.Property(e => e.Login)
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .HasColumnName("password");
            entity.Property(e => e.UserRoleId).HasDefaultValue(2)
                .HasColumnName("user_role_id");

            entity.HasOne(d => d.DocumentType).WithMany(p => p.Users)
                .HasForeignKey(d => d.DocumentTypeId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_document_type");

            entity.HasOne(d => d.UserRole).WithMany(p => p.Users)
                .HasForeignKey(d => d.UserRoleId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_user_role");

            entity.HasData(
                new User { Id = 1, Login = "librarian", Password = "1234", UserRoleId = 1, Email = "lib@lib.lib", LastName = "Librarian1"},
                new User { Id = 2, Login = "reader", Password = "111", UserRoleId = 2, Email = "reader1@lib.lib", LastName = "Reader1", DocumentTypeId = 1, DocumentNumber = "09123" },
                new User { Id = 3, Login = "reader2", Password = "222", UserRoleId = 2, Email = "reader2@lib.lib", LastName = "Reader2", DocumentTypeId = 2, DocumentNumber = "123321" }
                );
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_UserRole");

            entity.ToTable("UserRole");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Role)
                .HasColumnName("role");

            entity.HasData(
                new UserRole { Id = 1, Role = "Librarian" },
                new UserRole { Id = 2, Role = "Reader" });
        });

        modelBuilder.Entity<UserBook>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_UserBook");
            // entity.HasKey(e => new { e.UserId, e.BookId });

            entity.ToTable("UserBook");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.BookId).HasColumnName("book_id");

            entity.HasOne(d => d.Book).WithMany(b => b.UserBooks)
                .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_user_book_book");

            entity.HasOne(d => d.User).WithMany(u => u.UserBooks)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_user_book_user");

            entity.HasData(
                new UserBook { Id = 1, UserId = 2, BookId = 1, TookDate = new DateTime(2024, 1, 13), ReturnDate = new DateTime(2024, 1, 23) },
                new UserBook { Id = 2, UserId = 2, BookId = 2, TookDate = new DateTime(2024, 1, 11), ReturnDate = new DateTime(2024, 2, 3) },
                new UserBook { Id = 3, UserId = 2, BookId = 6, TookDate = new DateTime(2024, 2, 21), ReturnDate = new DateTime(2024, 3, 3) },
                new UserBook { Id = 4, UserId = 2, BookId = 6, TookDate = new DateTime(2023, 2, 21), ReturnDate = new DateTime(2023, 3, 3) },
                new UserBook { Id = 5, UserId = 2, BookId = 8, TookDate = new DateTime(2024, 2, 21), ReturnDate = new DateTime(2024, 4, 3) },
                new UserBook { Id = 6, UserId = 2, BookId = 8, TookDate = new DateTime(2023, 2, 21), ReturnDate = new DateTime(2023, 3, 3) },
                new UserBook { Id = 7, UserId = 2, BookId = 5, TookDate = new DateTime(2024, 2, 11), ReturnDate = new DateTime(2024, 3, 30) },
                new UserBook { Id = 8, UserId = 3, BookId = 7, TookDate = new DateTime(2024, 1, 11), ReturnDate = new DateTime(2024, 2, 3) },
                new UserBook { Id = 9, UserId = 3, BookId = 7, TookDate = new DateTime(2023, 1, 11), ReturnDate = new DateTime(2023, 2, 3) },
                new UserBook { Id = 10, UserId = 3, BookId = 3, TookDate = new DateTime(2024, 1, 14), ReturnDate = new DateTime(2024, 3, 30) }
            );
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
