using DBLibraryAccess;
using DBLibraryAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW16_EF
{
    internal class MenuStorage
    {
        public static void ShowLoginMenu(Action<string, string> loginFunc, bool showError = false)
        {
            Console.WriteLine("");
            if (showError)
            {
                Console.WriteLine("Invalid username or password.");
            }
            Console.WriteLine("");
            Console.WriteLine("Welcome to the Library!");
            Console.WriteLine("Please enter your username and password to log in.");
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();
            loginFunc(username, password);
        }
        public static void ShowAllAvailableBooks(ICollection<Book> books)
        {
            Console.WriteLine("All books available in library:");

            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
        }

        public static void ShowAllAuthors(ICollection<Author> authors)
        {
            Console.WriteLine("All authors:");
            foreach (var author in authors)
            {
                Console.WriteLine(author);
            }
        }

        public static void TakeAvailableBook(User currentUser, Func<string, Book> FindBookByTitlePartFunc, Func<UserBook, Book, bool, bool> SaveBookToUserFunc)
        {
            Console.Write("Enter the title of the book: ");
            string title = Console.ReadLine();
            Book book = FindBookByTitlePartFunc(title);
            if (book != null)
            {
                if (currentUser != null)
                {
                    var userBook = new UserBook
                    {
                        BookId = book.Id,
                        UserId = currentUser.Id,
                        TookDate = DateTime.Now,
                        ReturnDate = DateTime.Now.AddDays(30)
                    };
                    var result = SaveBookToUserFunc(userBook, book, false);
                    if (result)
                    {
                        Console.WriteLine($"Book {book.Title} taken successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Can not take this book.");
                    }
                }
                else
                {
                    Console.WriteLine("You are not logged in.");
                }
            }
            else
            {
                Console.WriteLine("Book not found or not available.");
            }
        }

        public static void ShowUserBooks(User user)
        {
            if (user != null)
            {
                Console.WriteLine($"User {user} books:");
                var userBooks = new List<UserBook>();
                foreach (var userBook in user.UserBooks.OrderByDescending(ub => ub.TookDate))
                {
                    if (userBooks.Any(ub => ub.BookId == userBook.BookId) || (userBook.Book.IsInLibrary ?? false))
                    {
                        continue;
                    }

                    userBooks.Add(userBook);
                }
                foreach (var userBook in userBooks.OrderBy(ub => ub.ReturnDate))
                {
                    if (userBook.ReturnDate < DateTime.Now)
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
            }
        }

        public static void ReturnBook(User? user, Func<UserBook, Book, bool, bool> SaveBookToUserFunc, Func<string, Book> FindBookByTitlePartFunc)
        {
            Console.Write("");
            Console.Write("Enter the title of the book: ");
            string title = Console.ReadLine();
            var book = FindBookByTitlePartFunc(title);

            if (book != null)
            {
                if (user != null)
                {
                    var userBook = user.UserBooks.FirstOrDefault(ub => ub.BookId == book.Id && ub.ReturnDate > DateTime.Now);
                    if (userBook != null)
                    {
                        userBook.ReturnDate = DateTime.Now;
                        var saved = SaveBookToUserFunc(userBook, book, true);
                        Console.WriteLine($"Book {book} returned successfully.");
                    }
                    else
                    {
                        Console.WriteLine("You don't have this book.");
                    }
                }
                else
                {
                    Console.WriteLine("You are not logged in.");
                }
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }

        public static void ShowUserHistory(User user)
        {
            Console.WriteLine("");
            Console.WriteLine($"User {user} history:");
            foreach (var userBook in user.UserBooks.OrderByDescending(ub => ub.TookDate))
            {
                Console.WriteLine(userBook);
            }
        }

        public static void ShowReaderMenuOptions()
        {
            Console.WriteLine("");
            Console.WriteLine("Welcome to the Library!");
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1. View all books available in library");
            Console.WriteLine("2. View my books");
            Console.WriteLine("3. View my history");
            Console.WriteLine("4. Find books by title");
            Console.WriteLine("5. Find books by author");
            Console.WriteLine("6. Take available book");
            Console.WriteLine("7. Return book");

            Console.WriteLine("0. Log out");
            Console.Write("Option: ");
        }

        public static void ShowFindBookByTitleMenu(Func<string, Book> FindBookByTitlePartFunc)
        {
            Console.Write("Enter the title of the book: ");
            string title = Console.ReadLine();
            var book = FindBookByTitlePartFunc(title);
            if (book != null)
            {
                Console.WriteLine($"Book found: {book}");
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }
        public static void ShowAddNewBookMenu(Func<string, int, string, string, string, int> SaveNewBookFunc)
        {
            Console.Write("Enter the title of the new book: ");
            string title = Console.ReadLine();
            Console.Write("Enter the publication year: ");
            int publicationYear = int.Parse(Console.ReadLine());
            Console.Write("Enter the country: ");
            string country = Console.ReadLine();
            Console.Write("Enter the city: ");
            string city = Console.ReadLine();
            Console.Write("Enter the author's name: ");
            string authorName = Console.ReadLine();
            int result = SaveNewBookFunc(title, publicationYear, country, city, authorName);
            if (result > 0)
            {
                Console.WriteLine($"Book {title} added successfully.");
            }
            else
            {
                Console.WriteLine($"Book {title} not added.");
            }
        }

        public static void ShowAllUsers(ICollection<User> users)
        {
            Console.WriteLine("All users:");
            foreach (var user in users)
            {
                Console.WriteLine(user);
            }
        }

        public static void ShowFindBookByAuthorMenu(Func<string, ICollection<Book?>>FindBookByAuthorFunc)
        {
            Console.Write("Enter the name of the author: ");
            string author = Console.ReadLine();

            var books = FindBookByAuthorFunc(author);
            if (books.Any())
            {
                Console.WriteLine($"Books found by reauest \"{author}\":");
                foreach (var book in books)
                {
                    Console.WriteLine(book);
                }
            }
            else
            {
                Console.WriteLine($"No books found by reauest \"{author}\".");
            }
        }

        public static void ShowAddNewAuthorMenu(Func<string, string, string, DateTime, int> SaveNewAuthor)
        {
            Console.Write("Enter the first name of the new  author: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter the last name of the author: ");
            string lastName = Console.ReadLine();
            Console.Write("Enter the alias name of the author: ");
            string aliasName = Console.ReadLine();
            Console.Write("Enter the date of birth of the author: ");
            DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());
            int result = SaveNewAuthor(firstName, lastName, aliasName, dateOfBirth);
            if (result > 0)
            {
                Console.WriteLine($"Author {firstName} {lastName} added successfully.");
            }
            else
            {
                Console.WriteLine($"Author {firstName} {lastName} not added.");
            }
        }

        public static void ShowLibrarianMenuOptions()
        {
            Console.WriteLine("");
            Console.WriteLine("Welcome to the Library!");
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1. View all books available in library");
            Console.WriteLine("2. View all authors");
            Console.WriteLine("3. View all users");
            Console.WriteLine("4. View user history");
            Console.WriteLine("5. View user books");
            Console.WriteLine("6. Add new book");
            Console.WriteLine("7. Add new author");
            Console.WriteLine("8. Add new user");
            Console.WriteLine("9. Update book");
            Console.WriteLine("10. Update author");
            Console.WriteLine("11. Update user");
            Console.WriteLine("12. Delete book");
            Console.WriteLine("13. Delete author");
            Console.WriteLine("14. Delete user");
            Console.WriteLine("15. Users who own books");
            Console.WriteLine("0. Log out");
            Console.Write("Option: ");
        }

        public static void ShowAddNewUserMenu(Func<string, string, string, string, int> SaveNewUserFunc)
        {
            Console.Write("Enter the first name of the new user: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter the last name of the user: ");
            string lastName = Console.ReadLine();
            Console.Write("Enter the login of the user: ");
            string login = Console.ReadLine();
            Console.Write("Enter the password of the user: ");
            string password = Console.ReadLine();
            int result = SaveNewUserFunc(firstName, lastName, login, password);
            if (result > 0)
            {
                Console.WriteLine($"User {firstName} {lastName} added successfully.");
            }
            else
            {
                Console.WriteLine("User not added.");
            }
        }

        public static void ShowUpdateBookMenu(Func<string, Book> FindBookByTitlePartFunc, Func<Book, string, int, string, string, int> UpdateBookFunc)
        {
            Console.Write("Enter the title of the book to update: ");
            string title = Console.ReadLine();
            var book = FindBookByTitlePartFunc(title);
            if (book != null)
            {
                Console.Write("Enter the new title of the book: ");
                string newTitle = Console.ReadLine();
                Console.Write("Enter the new publication year: ");
                int newPublicationYear = int.Parse(Console.ReadLine());
                Console.Write("Enter the new country: ");
                string newCountry = Console.ReadLine();
                Console.Write("Enter the new city: ");
                string newCity = Console.ReadLine();
                int result = UpdateBookFunc(book, newTitle, newPublicationYear, newCountry, newCity);
                if (result == 1)
                {
                    Console.WriteLine($"Book {book.Title} updated successfully.");
                }
                else
                {
                    Console.WriteLine("Book not found.");
                }
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }

        public static void ShowUpdateAuthorMenu(Func<string, Author> FindAuthorByNamePart, Func<Author,string,string,string,DateTime, int> UpdateAuthorAction)
        {
            Console.Write("Enter the name of the author to update: ");
            string name = Console.ReadLine();
            Author? author = FindAuthorByNamePart(name);
            if (author != null)
            {
                Console.Write("Enter the new first name of the author: ");
                string newFirstName = Console.ReadLine();
                Console.Write("Enter the new last name of the author: ");
                string newLastName = Console.ReadLine();
                Console.Write("Enter the new alias name of the author: ");
                string newAliasName = Console.ReadLine();
                Console.Write("Enter the new date of birth of the author: ");
                DateTime newDateOfBirth = DateTime.Parse(Console.ReadLine());
                var result = UpdateAuthorAction(author, newFirstName, newLastName, newAliasName, newDateOfBirth);
                
                if (result == 1)
                {
                    Console.WriteLine($"Author {author} updated successfully.");
                }
                else 
                {
                    Console.WriteLine("Author not updated.");
                }
            }
            else
            {
                Console.WriteLine("Author not found.");
            }
        }

        public static void ShowUpdateUserMenu(Func<string, User> FindUserByLoginNameFunc, Func<User, string, string, string, string, int> UpdateUserAction)
        {
            Console.Write("Enter the login of the user to update: ");
            string login = Console.ReadLine();
            User? user = FindUserByLoginNameFunc(login);
            if (user != null)
            {
                Console.Write("Enter the new first name of the user: ");
                string newFirstName = Console.ReadLine();
                Console.Write("Enter the new last name of the user: ");
                string newLastName = Console.ReadLine();
                Console.Write("Enter the new login of the user: ");
                string newLogin = Console.ReadLine();
                Console.Write("Enter the new password of the user: ");
                string newPassword = Console.ReadLine();
                var result = UpdateUserAction(user, newFirstName, newLastName, newLogin, newPassword);
                if (result > 0)
                {
                    Console.WriteLine($"User {user} updated successfully.");
                }
                else
                {
                    Console.WriteLine("User not found.");
                }
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }

        public static void ShowDeleteBookMenu(Func<string, Book> FindBookByTitle, Func<Book, int> DeleteBookAction)
        {
            Console.Write("Enter the title of the book to delete: ");
            string title = Console.ReadLine();
            Book? book = FindBookByTitle(title);
            if (book != null)
            {
                var result = DeleteBookAction(book);
                if (result > 0)
                {
                    Console.WriteLine($"Book {book.Title} deleted successfully.");
                }
                else
                {
                    Console.WriteLine($"Book {book.Title} was not deleted.");
                }
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }

        public static void ShowDeleteAuthorMenu(Func<string, Author> FindAuthorByNameAction, Func<Author, int> DeleteAuthorAction)
        {
            Console.Write("Enter the name of the author to delete: ");
            string name = Console.ReadLine();
            Author? author = FindAuthorByNameAction(name);
            if (author != null)
            {
                var result = DeleteAuthorAction(author);
                if (result == 1)
                {
                    Console.WriteLine($"Author {author} deleted successfully.");
                }
                else
                {
                    Console.WriteLine($"Author {author} was not deleted.");
                }
            }
            else
            {
                Console.WriteLine("Author not found.");
            }
        }

        public static void ShowDeleteUserMenu(Func<string, User> FindUserByLoginNameAction, Func<User, int> DeleteUserAction)
        {
            Console.Write("Enter the login of the user to delete: ");
            string login = Console.ReadLine();
            User? user = FindUserByLoginNameAction(login);
            if (user != null)
            {
                var result = DeleteUserAction(user);
                if (result > 0)
                {
                    Console.WriteLine($"User {user} deleted successfully.");
                }
                else
                {
                    Console.WriteLine($"User {user} was not deleted.");
                }
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }
    }
}
