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
        private AuthController AuthSystem { get; set; }

        private ILibraryModelContext LibraryModelContext { get; set; }

        public LibraryController(ILibraryModelContext libraryModelContext)
        {
            AuthSystem = new AuthController(libraryModelContext);
            LibraryModelContext = libraryModelContext;
        }

        public void Start()
        {
            AuthSystem.Logout();
            MenuStorage.ShowLoginMenu(LoginAction);
        }
        
        private void LoginAction(string username, string password)
        {
            if (username != null && password != null)
            {
                if (AuthSystem.Login(username, password))
                {
                    MainMenuAction();
    }
                else
                {
                    MenuStorage.ShowLoginMenu(LoginAction, true);
                }
            }
        }
        private void MainMenuAction()
        {
            if (!AuthSystem.IsLoggedIn || AuthSystem.GetCurrentUser() == null)
            {
                MenuStorage.ShowLoginMenu(LoginAction);
                return;
            }

            if (AuthSystem.GetCurrentUser().UserRole.Role == "Librarian")
            {
                LibrarianMenuAction();
                return;
            }
            
            ReaderMenuAction();
        }

        private void ReaderMenuAction()
        {
            /*
                1. View all books available in library
                2. View my books
                3. View my history
                4. Find books by title
                5. Find books by author
                6. Take available book
                7. Return book
                0. Log out
             *             */
            MenuStorage.ShowReaderMenuOptions();

            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    LibraryModelContext.Books.Include(b => b.AuthorBooks).Load();
                    LibraryModelContext.Authors.Include(b => b.AuthorBooks).Load();
                    MenuStorage.ShowAllAvailableBooks(LibraryModelContext.Books.Where(b => b.IsInLibrary ?? false).ToList());
                    break;
                case "2":
                    LibraryModelContext.Users.Include(u => u.UserBooks).Load();
                    LibraryModelContext.Authors.Include(b => b.AuthorBooks).Load();
                    LibraryModelContext.Books.Include(b => b.AuthorBooks).Load();
                    LibraryModelContext.Books.Include(b => b.UserBooks).Load();
                    MenuStorage.ShowUserBooks(AuthSystem.GetCurrentUser());
                    break;
                case "3":
                    LibraryModelContext.Users.Include(u => u.UserBooks).Load();
                    LibraryModelContext.Authors.Include(b => b.AuthorBooks).Load();
                    LibraryModelContext.Books.Include(b => b.AuthorBooks).Load();
                    LibraryModelContext.Books.Include(b => b.UserBooks).Load();
                    MenuStorage.ShowUserHistory(AuthSystem.GetCurrentUser());
                    break;
                case "4":
                    MenuStorage.ShowFindBookByTitleMenu(FindBookByTitlePartAction);
                    break;
                case "5":
                    MenuStorage.ShowFindBookByAuthorMenu(FindBookByAuthorAction);
                    break;
                case "6":
                    LibraryModelContext.Books.Include(b => b.AuthorBooks).Load();
                    LibraryModelContext.Authors.Include(b => b.AuthorBooks).Load();
                    MenuStorage.ShowAllAvailableBooks(LibraryModelContext.Books.Where(b => b.IsInLibrary ?? false).ToList());

                    LibraryModelContext.Books.Include(b => b.UserBooks).Load();
                    MenuStorage.TakeAvailableBook(AuthSystem.GetCurrentUser(), FindBookByTitlePartAction, SaveBookToUserAction);

                    break;
                case "7":
                    User? user = AuthSystem.GetCurrentUser();
                    LibraryModelContext.Users.Include(u => u.UserBooks).Load();
                    LibraryModelContext.Authors.Include(b => b.AuthorBooks).Load();
                    LibraryModelContext.Books.Include(b => b.AuthorBooks).Load();
                    LibraryModelContext.Books.Include(b => b.UserBooks).Load();
                    MenuStorage.ShowUserBooks(user);
                    
                    MenuStorage.ReturnBook(user, SaveBookToUserAction, FindBookByTitlePartAction);
                    break;
                case "0":
                    AuthSystem.Logout();
                    break;
                default:
                    break;
            }
            MainMenuAction();
        }

        private Book FindBookByTitlePartAction(string title)
        {
            LibraryModelContext.Books.Include(b => b.UserBooks).Load();
            return LibraryModelContext.Books.FirstOrDefault(b => b.Title.Contains(title) && (b.IsInLibrary ?? false));
        }

        private ICollection<Book?> FindBookByAuthorAction(string author)
        {
            LibraryModelContext.Books.Include(b => b.AuthorBooks).Load();
            LibraryModelContext.AuthorBooks.Include(b => b.Author).Load();
            LibraryModelContext.Authors.Include(b => b.AuthorBooks).Load();
            var books = LibraryModelContext.Books.ToList().Where(b => b.Authors.Any(a => a.IsComplyWith(author))).ToList();
            return books;
        }

        private bool SaveBookToUserAction(UserBook userBook, Book book, bool isInLibrary)
        {
            LibraryModelContext.UserBooks.Add(userBook);
            book.IsInLibrary = isInLibrary;
            var result = LibraryModelContext.SaveChanges();

            return result == 2;
        }

        private void LibrarianMenuAction()
        {
            /*
                1. View all books available in library
                2. View all authors
                3. View all users
                4. View user history
                5. View user books
                6. Add new book
                7. Add new author
                8. Add new user
                9. Update book
                10. Update author
                11. Update user
                12. Delete book
                13. Delete author
                14. Delete user
                0. Log out
            */
            MenuStorage.ShowLibrarianMenuOptions();

            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    LibraryModelContext.Books.Include(b => b.AuthorBooks).Load();
                    LibraryModelContext.Authors.Include(b => b.AuthorBooks).Load();
                    var books = LibraryModelContext.Books.Where(b => b.IsInLibrary ?? false).ToList();
                    MenuStorage.ShowAllAvailableBooks(books);
                    break;
                case "2":
                    LibraryModelContext.Authors.Include(a => a.AuthorBooks).Load();
                    var authors = LibraryModelContext.Authors.ToList();
                    MenuStorage.ShowAllAuthors(authors);
                    break;
                case "3":
                    MenuStorage.ShowAllUsers(LibraryModelContext.Users.ToList());
                    break;
                case "4":
                    LibraryModelContext.Users.Include(u => u.UserBooks).Load();
                    LibraryModelContext.Authors.Include(b => b.AuthorBooks).Load();
                    LibraryModelContext.Books.Include(b => b.AuthorBooks).Load();
                    LibraryModelContext.Books.Include(b => b.UserBooks).Load();
                    foreach (var user in LibraryModelContext.Users.ToList())
                    {
                        MenuStorage.ShowUserHistory(user);
                    }
                    break;
                case "5":
                    LibraryModelContext.Users.Include(u => u.UserBooks).Load();
                    LibraryModelContext.Books.Include(b => b.UserBooks).Load();
                    List<User> users = LibraryModelContext.Users.ToList();
                    foreach (var user in users)
                    {
                        MenuStorage.ShowUserBooks(user); //////
                    }
                    break;
                case "6":
                    MenuStorage.ShowAddNewBookMenu(SaveNewBookAction);
                    break;
                case "7":
                    MenuStorage.ShowAddNewAuthorMenu(SaveNewAuthorAction);
                    break;
                case "8":
                    MenuStorage.ShowAddNewUserMenu(SaveNewUserAction);
                    break;
                case "9":
                    LibraryModelContext.Books.Include(b => b.AuthorBooks).Load();
                    MenuStorage.ShowUpdateBookMenu(FindBookByTitlePartAction, UpdateBookFunc);
                    break;
                case "10":
                    LibraryModelContext.Authors.Include(a => a.AuthorBooks).Load();
                    MenuStorage.ShowUpdateAuthorMenu(FindAuthorByNamePartAction, UpdateAuthorAction);
                    break;
                case "11":
                    LibraryModelContext.Users.Include(u => u.UserBooks).Load();
                    MenuStorage.ShowUpdateUserMenu(FindUserByLoginNameAction, UpdateUserAction);
                    break;
                case "12":
                    LibraryModelContext.Books.Include(b => b.AuthorBooks).Load();
                    MenuStorage.ShowDeleteBookMenu(FindBookByTitlePartAction, DeleteBookAction);
                    break;
                case "13":
                    LibraryModelContext.Authors.Include(a => a.AuthorBooks).Load();
                    MenuStorage.ShowDeleteAuthorMenu(FindAuthorByNamePartAction, DeleteAuthorAction);
                    break;
                case "14":
                    LibraryModelContext.Users.Include(u => u.UserBooks).Load();
                    MenuStorage.ShowDeleteUserMenu(FindUserByLoginNameAction, DeleteUserAction);
                    break;
                case "0":
                    AuthSystem.Logout();
                    break;
                default:
                    break;
            }
            MainMenuAction();
        }

        private int SaveNewBookAction(string title, int publicationYear, string country, string city, string authorName)
        {
            var author = LibraryModelContext.Authors.FirstOrDefault(a => a.LastName == authorName || a.FirstName == authorName);
            if (author == null)
            {
                author = new Author
                {
                    LastName = authorName
                };
                LibraryModelContext.Authors.Add(author);
                LibraryModelContext.SaveChanges();
            }
            var book = new Book
            {
                Title = title,
                PublicationYear = publicationYear,
                Country = country,
                City = city
            };
            LibraryModelContext.Books.Add(book);
            LibraryModelContext.SaveChanges();
            var authorBook = new AuthorBook
            {
                AuthorId = author.Id,
                BookId = book.Id
            };
            LibraryModelContext.AuthorBooks.Add(authorBook);
            var result = LibraryModelContext.SaveChanges();
            return result;
        }


        private int SaveNewAuthorAction(string firstName, string lastName, string aliasName, DateTime dateOfBirth)
        {
            var author = new Author
            {
                FirstName = firstName,
                LastName = lastName,
                AliasName = aliasName,
                DateOfBirth = dateOfBirth
            };
            LibraryModelContext.Authors.Add(author);
            var result = LibraryModelContext.SaveChanges();
            return result;
        }

        private int SaveNewUserAction(string firstName, string lastName, string login, string password)
        {
            var readerRole = LibraryModelContext.UserRoles.FirstOrDefault(r => r.Role == "Reader");
            var user = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Login = login,
                Password = password,
                UserRoleId = readerRole.Id
            };
            LibraryModelContext.Users.Add(user);
            LibraryModelContext.SaveChanges();
            return LibraryModelContext.SaveChanges();
        }

        
        private int UpdateBookFunc(Book book, string newTitle, int newPublicationYear, string newCountry, string newCity)
        {
            book.Title = newTitle;
            book.PublicationYear = newPublicationYear;
            book.Country = newCountry;
            book.City = newCity;
            return LibraryModelContext.SaveChanges();
        }


        private int UpdateAuthorAction(Author author, string newFirstName, string newLastName, string newAliasName, DateTime newDateOfBirth)
        {
            author.FirstName = newFirstName;
            author.LastName = newLastName;
            author.AliasName = newAliasName;
            author.DateOfBirth = newDateOfBirth;
            return LibraryModelContext.SaveChanges();
        }

        private Author? FindAuthorByNamePartAction(string name)
        {
            return LibraryModelContext.Authors.FirstOrDefault(a => a.LastName.Contains(name) || a.FirstName.Contains(name));
        }

        private int UpdateUserAction(User user, string newFirstName, string newLastName, string newLogin, string newPassword)
        {
            var readerRole = LibraryModelContext.UserRoles.FirstOrDefault(r => r.Role == "Reader");
            user.FirstName = newFirstName;
            user.LastName = newLastName;
            user.Login = newLogin;
            user.Password = newPassword;
            user.UserRoleId = readerRole.Id;
            return LibraryModelContext.SaveChanges();
        }

        private User? FindUserByLoginNameAction(string login)
        {
            return LibraryModelContext.Users.FirstOrDefault(u => u.Login.Contains(login));
        }

        private int DeleteBookAction(Book book)
        {
            LibraryModelContext.Books.Remove(book);
            return LibraryModelContext.SaveChanges();
        }

        private int DeleteAuthorAction(Author author)
        {
            LibraryModelContext.Authors.Remove(author);
            return LibraryModelContext.SaveChanges();
        }

        private int DeleteUserAction(User? user)
        {
            LibraryModelContext.Users.Remove(user);
            return LibraryModelContext.SaveChanges();
        }
    }
}
