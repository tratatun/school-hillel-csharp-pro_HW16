﻿// <auto-generated />
using System;
using DBLibraryAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DBLibraryAccess.Migrations
{
    [DbContext(typeof(HillelHw15Context))]
    [Migration("20240307055857_UserBookRelation")]
    partial class UserBookRelation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DBLibraryAccess.Model.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AliasName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("alias_name");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("date")
                        .HasColumnName("date_of_birth");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("last_name");

                    b.HasKey("Id")
                        .HasName("PK_Author");

                    b.ToTable("Author", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateOfBirth = new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "John",
                            LastName = "Doe"
                        },
                        new
                        {
                            Id = 2,
                            DateOfBirth = new DateTime(1985, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Jane",
                            LastName = "Doe"
                        },
                        new
                        {
                            Id = 3,
                            DateOfBirth = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Jack",
                            LastName = "Doe"
                        });
                });

            modelBuilder.Entity("DBLibraryAccess.Model.AuthorBook", b =>
                {
                    b.Property<int?>("AuthorId")
                        .HasColumnType("int")
                        .HasColumnName("author_id");

                    b.Property<int?>("BookId")
                        .HasColumnType("int")
                        .HasColumnName("book_id");

                    b.HasKey("AuthorId", "BookId");

                    b.HasIndex("BookId");

                    b.ToTable("AuthorBook", (string)null);

                    b.HasData(
                        new
                        {
                            AuthorId = 1,
                            BookId = 1
                        },
                        new
                        {
                            AuthorId = 2,
                            BookId = 1
                        },
                        new
                        {
                            AuthorId = 3,
                            BookId = 2
                        });
                });

            modelBuilder.Entity("DBLibraryAccess.Model.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("city");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("country");

                    b.Property<int?>("PublicationYear")
                        .HasColumnType("int")
                        .HasColumnName("publication_year");

                    b.Property<int?>("PublisherCode")
                        .HasColumnType("int")
                        .HasColumnName("publisher_code");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("PK_Book");

                    b.HasIndex("PublisherCode");

                    b.ToTable("Book", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Kyiv",
                            Country = "Ukraine",
                            PublicationYear = 2021,
                            PublisherCode = 1,
                            Title = "Book1"
                        },
                        new
                        {
                            Id = 2,
                            City = "Kharkiv",
                            Country = "Ukraine",
                            PublicationYear = 2020,
                            PublisherCode = 2,
                            Title = "Book2"
                        },
                        new
                        {
                            Id = 3,
                            City = "Lviv",
                            Country = "Ukraine",
                            PublicationYear = 2019,
                            PublisherCode = 3,
                            Title = "Book3"
                        },
                        new
                        {
                            Id = 4,
                            City = "Odessa",
                            Country = "USA",
                            PublicationYear = 2018,
                            PublisherCode = 3,
                            Title = "Book4"
                        });
                });

            modelBuilder.Entity("DBLibraryAccess.Model.DocumentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("type");

                    b.HasKey("Id")
                        .HasName("PK_Document");

                    b.ToTable("DocumentType", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Passport"
                        },
                        new
                        {
                            Id = 2,
                            Type = "Driver License"
                        },
                        new
                        {
                            Id = 3,
                            Type = "ID Card"
                        });
                });

            modelBuilder.Entity("DBLibraryAccess.Model.PublisherCode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("code");

                    b.HasKey("Id")
                        .HasName("PK_Publishe");

                    b.ToTable("PublisherCode", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "PC1"
                        },
                        new
                        {
                            Id = 2,
                            Code = "PC2"
                        },
                        new
                        {
                            Id = 3,
                            Code = "PC3"
                        });
                });

            modelBuilder.Entity("DBLibraryAccess.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DocumentNumber")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("document_number");

                    b.Property<int?>("DocumentTypeId")
                        .HasColumnType("int")
                        .HasColumnName("document_type_id");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("last_name");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("login");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("password");

                    b.Property<int?>("UserRoleId")
                        .HasColumnType("int")
                        .HasColumnName("user_role_id");

                    b.HasKey("Id")
                        .HasName("PK_User");

                    b.HasIndex("DocumentTypeId");

                    b.HasIndex("UserRoleId");

                    b.ToTable("User", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "lib@lib.lib",
                            LastName = "Librarian1",
                            Login = "librarian",
                            Password = "1234",
                            UserRoleId = 1
                        },
                        new
                        {
                            Id = 2,
                            DocumentNumber = "09123",
                            DocumentTypeId = 1,
                            Email = "reader1@lib.lib",
                            LastName = "Reader1",
                            Login = "reader",
                            Password = "111",
                            UserRoleId = 2
                        },
                        new
                        {
                            Id = 3,
                            DocumentNumber = "123321",
                            DocumentTypeId = 2,
                            Email = "reader2@lib.lib",
                            LastName = "Reader2",
                            Login = "reader2",
                            Password = "222",
                            UserRoleId = 2
                        });
                });

            modelBuilder.Entity("DBLibraryAccess.Model.UserBook", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.Property<int>("BookId")
                        .HasColumnType("int")
                        .HasColumnName("book_id");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("TookDate")
                        .HasColumnType("datetime2");

                    b.HasKey("UserId", "BookId");

                    b.HasIndex("BookId");

                    b.ToTable("UserBook", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = 2,
                            BookId = 1,
                            ReturnDate = new DateTime(2024, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TookDate = new DateTime(2024, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            UserId = 2,
                            BookId = 2,
                            ReturnDate = new DateTime(2024, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TookDate = new DateTime(2024, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            UserId = 3,
                            BookId = 3,
                            TookDate = new DateTime(2024, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("DBLibraryAccess.Model.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("role");

                    b.HasKey("Id")
                        .HasName("PK_UserRole");

                    b.ToTable("UserRole", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Role = "Librarian"
                        },
                        new
                        {
                            Id = 2,
                            Role = "Reader"
                        });
                });

            modelBuilder.Entity("DBLibraryAccess.Model.AuthorBook", b =>
                {
                    b.HasOne("DBLibraryAccess.Model.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_author");

                    b.HasOne("DBLibraryAccess.Model.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_book");

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("DBLibraryAccess.Model.Book", b =>
                {
                    b.HasOne("DBLibraryAccess.Model.PublisherCode", "PublisherCodeNavigation")
                        .WithMany("Books")
                        .HasForeignKey("PublisherCode")
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("FK_publisher_code");

                    b.Navigation("PublisherCodeNavigation");
                });

            modelBuilder.Entity("DBLibraryAccess.Model.User", b =>
                {
                    b.HasOne("DBLibraryAccess.Model.DocumentType", "DocumentType")
                        .WithMany("Users")
                        .HasForeignKey("DocumentTypeId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("FK_document_type");

                    b.HasOne("DBLibraryAccess.Model.UserRole", "UserRole")
                        .WithMany("Users")
                        .HasForeignKey("UserRoleId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("FK_user_role");

                    b.Navigation("DocumentType");

                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("DBLibraryAccess.Model.UserBook", b =>
                {
                    b.HasOne("DBLibraryAccess.Model.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_user_book_book");

                    b.HasOne("DBLibraryAccess.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_user_book_user");

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DBLibraryAccess.Model.DocumentType", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("DBLibraryAccess.Model.PublisherCode", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("DBLibraryAccess.Model.UserRole", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
