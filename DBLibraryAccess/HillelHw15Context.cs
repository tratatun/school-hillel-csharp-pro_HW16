using System;
using System.Collections.Generic;
using DBLibraryAccess.Model;
using Microsoft.EntityFrameworkCore;

namespace DBLibraryAccess;

public partial class HillelHw15Context : DbContext
{
    public HillelHw15Context()
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<AuthorBook> AuthorBooks { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<DocumentType> DocumentTypes { get; set; }

    public virtual DbSet<Librarian> Librarians { get; set; }

    public virtual DbSet<PublisherCode> PublisherCodes { get; set; }

    public virtual DbSet<Reader> Readers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=DESKTOP-84M0NOK\\SQLEXPRESS;Initial Catalog=Hillel_HW15_1;Integrated Security=True;Trust Server Certificate=True");
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
        });

        modelBuilder.Entity<AuthorBook>(entity =>
        {
            entity.HasKey(e => new { e.AuthorId, e.BookId });
            
            entity.ToTable("AuthorBook");

            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.BookId).HasColumnName("book_id");

            entity.HasOne(d => d.Author).WithMany()
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_author");

            entity.HasOne(d => d.Book).WithMany()
                .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_book");
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
            entity.Property(e => e.PublisherCode).HasColumnName("publisher_code");
            entity.Property(e => e.Title)
                .HasColumnName("title");

            entity.HasOne(d => d.PublisherCodeNavigation).WithMany(p => p.Books)
                .HasForeignKey(d => d.PublisherCode)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_publisher_code");
        });

        modelBuilder.Entity<DocumentType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Document");

            entity.ToTable("DocumentType");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Type)
                .HasColumnName("type");
        });

        modelBuilder.Entity<Librarian>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Libraria");

            entity.ToTable("Librarian");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasColumnName("email");
            entity.Property(e => e.Login)
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .HasColumnName("password");
        });

        modelBuilder.Entity<PublisherCode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Publishe");

            entity.ToTable("PublisherCode");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasColumnName("code");
        });

        modelBuilder.Entity<Reader>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Reader");

            entity.ToTable("Reader");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DocumentNumber)
                .HasColumnName("document_number");
            entity.Property(e => e.DocumentTypeId).HasColumnName("document_type_id");
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

            entity.HasOne(d => d.DocumentType).WithMany(p => p.Readers)
                .HasForeignKey(d => d.DocumentTypeId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_document_type");
        });

        // Add data to the tables
        modelBuilder.Entity<Author>().HasData(
            new Author {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                AliasName = "JD",
                DateOfBirth = new DateTime(1980, 11, 1)
            },
            new Author {
                Id = 2,
                FirstName = "Jane",
                LastName = "Doe",
                AliasName = "JD",
                DateOfBirth = new DateTime(1990, 12, 13)
            });
        modelBuilder.Entity<Book>().HasData(
            new Book
            {
                Id = 1,
                Title = "Book 1",
                City = "Kyiv",
                Country = "Ukraine",
                PublicationYear = 2020,
                PublisherCode = 1
            },
            new Book
            {
                Id = 2,
                Title = "Book 2",
                City = "Kharkiv",
                Country = "Ukraine",
                PublicationYear = 2021,
                PublisherCode = 2
            },
            new Book
            {
                Id = 3,
                Title = "Book 4",
                City = "Madrid",
                Country = "Spain",
                PublicationYear = 2021,
                PublisherCode = 2
            });
        modelBuilder.Entity<PublisherCode>().HasData(
            new PublisherCode
            {
                Id = 1,
                Code = "Pub 123456"
            },
            new PublisherCode
            {
                Id = 2,
                Code = "Pub 654321"
            });
        modelBuilder.Entity<AuthorBook>().HasData(
            new AuthorBook
            {
                AuthorId = 1,
                BookId = 1
            },
            new AuthorBook
            {
                AuthorId = 2,
                BookId = 2
            });
        modelBuilder.Entity<DocumentType>().HasData(
            new DocumentType
            {
                Id = 1,
                Type = "Passport"
            },
            new DocumentType
            {
                Id = 2,
                Type = "Driver's License"
            });
        modelBuilder.Entity<Reader>().HasData(
            new Reader
            {
                Id = 1,
                DocumentNumber = "AA123456",
                DocumentTypeId = 1,
                Email = "asd1@asd2.as",
                FirstName = "Ivan",
                LastName = "Ivanov",
            },
            new Reader
            {
                Id = 2,
                DocumentNumber = "BB654321",
                DocumentTypeId = 2,
                Email = "asd2@asd2.as",
                FirstName = "Oleksandr",
                LastName = "Nikiforov",
            },
            new Reader
            {
                Id = 3,
                DocumentNumber = "CC654321",
                DocumentTypeId = 2,
                Email = "asd3@asd2.as",
                FirstName = "Valeriy",
                LastName = "Zaluznyy",
            });
        modelBuilder.Entity<Librarian>().HasData(
            new Librarian
            {
                Id = 1,
                Email = "asdf1@asdf.as",
                Login = "librarian1",
                Password = "1234"
            });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
