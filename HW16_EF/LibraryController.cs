using DBLibraryAccess;
using DBLibraryAccess.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW16_EF
{
    internal class LibraryController
    {
        private AuthSystem AuthSystem { get; set; }

        private ILibraryModelContext LibraryModelContext { get; set; }

        public LibraryController(ILibraryModelContext libraryModelContext)
        {
            AuthSystem = new AuthSystem(libraryModelContext);
            LibraryModelContext = libraryModelContext;
        }

        public void ShowLoginMenu()
        {
            Console.WriteLine("Welcome to the Library!");
            Console.WriteLine("Please enter your username and password to log in.");
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();
            if (username != null && password != null)
            {
                if(AuthSystem.Login(username, password))
                {
                    ShowMainMenu();
                }
                else
                {
                    ShowLoginMenu();
                }
            }
        }
        private void ShowMainMenu()
        {
            Console.WriteLine("Welcome to the Library!");
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1. View all books");
            Console.WriteLine("2. View my books");
            Console.WriteLine("3. View my history");
            Console.WriteLine("4. Find book by title");
            Console.WriteLine("5. Find book by author");

            Console.WriteLine("0. Log out");
            Console.Write("Option: ");
            string option = Console.ReadLine();
            
            switch (option)
            {
                case "1":
                    ShowAllBooks();
                    break;
                case "2":
                    ShowUserBooks();
                    break;
                case "3":
                    ShowUserHistory();
                    break;
                case "4":
                    FindBookByTitle();
                    break;
                case "5":
                    FindBookByAuthor();
                    break;
                case "0":
                    AuthSystem.Logout();
                    ShowLoginMenu();
                    break;
                default:
                    ShowMainMenu();
                    break;
            }
        }

        private void ShowUserBooks()
        {
            User? currentUser = AuthSystem.GetCurrentUser();
            LibraryModelContext.Users.Include(u => u.UserBooks).Load();
            LibraryModelContext.Authors.Include(b => b.AuthorBooks).Load();
            LibraryModelContext.Books.Include(b => b.AuthorBooks).Load();
            LibraryModelContext.Books.Include(b => b.UserBooks).Load();
            if (currentUser != null)
            {
                Console.WriteLine("My books:");
                var userBooks = new List<UserBook>();
                foreach (var userBook in currentUser.UserBooks.OrderByDescending(ub=>ub.TookDate))
                {
                    if (userBooks.Any(ub => ub.BookId == userBook.BookId) || (userBook.Book.IsInLibrary ?? false))
                    {
                        continue;
                    }

                    userBooks.Add(userBook);
                }
                foreach (var userBook in userBooks.OrderBy(ub => ub.ReturnDate))
                {
                    if (userBook.ReturnDate<DateTime.Now)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(userBook);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.WriteLine(userBook);
                    }
                }
                ShowMainMenu();
            }
            else
            {
                ShowLoginMenu();
            }
        }

        private void ShowUserHistory()
        {
            User? currentUser = AuthSystem.GetCurrentUser();
            LibraryModelContext.Users.Include(u => u.UserBooks).Load();
            LibraryModelContext.Authors.Include(b => b.AuthorBooks).Load();
            LibraryModelContext.Books.Include(b => b.AuthorBooks).Load();
            LibraryModelContext.Books.Include(b => b.UserBooks).Load();
            if (currentUser != null)
            {
                Console.WriteLine("My history:");
                foreach (var userBook in currentUser.UserBooks.OrderByDescending(ub => ub.TookDate))
                {
                    Console.WriteLine(userBook);
                }
                ShowMainMenu();
            }
            else
            {
                ShowLoginMenu();
            }
        }

        private void FindBookByTitle()
        {
            Console.Write("Enter the title of the book: ");
            string title = Console.ReadLine();
            LibraryModelContext.Books.Include(b => b.UserBooks).Load();
            var book = LibraryModelContext.Books.FirstOrDefault(b => b.Title.Contains(title));
            if (book != null)
            {
                Console.WriteLine($"Book found: {book.Title}");
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
            ShowMainMenu();
        }

        private void FindBookByAuthor()
        {
            Console.Write("Enter the name of the author: ");
            string author = Console.ReadLine();
            LibraryModelContext.Books.Include(b => b.AuthorBooks).Load();
            LibraryModelContext.Authors.Include(b => b.AuthorBooks).Load();
            var books = LibraryModelContext.Books.Where(b => b.Authors.Any(a => a.IsComplyWith(author))).ToList();
            if (books.Any())
            {
                Console.WriteLine($"Books found by {author}:");
                foreach (var book in books)
                {
                    Console.WriteLine(book.Title);
                }
            }
            else
            {
                Console.WriteLine($"No books found by {author}.");
            }
            ShowMainMenu();
        }

        private void ShowAllBooks()
        {
            Console.WriteLine("All books:");
            foreach (var book in LibraryModelContext.Books.Where(b=> b.IsInLibrary ?? false))
            {
                Console.WriteLine(book.Title);
            }
            ShowMainMenu();
        }
    }
}
