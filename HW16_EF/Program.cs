using DBLibraryAccess;
using DBLibraryAccess.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HW16_EF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var context = new HillelHw15Context();

            while (true)
            {
                Console.WriteLine("1. Librarian login");
                Console.WriteLine("2. Librarian registration");
                Console.WriteLine("3. Reader login");
                Console.WriteLine("4. Reader registration");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Librarian login");
                        Console.Write("Enter your login: ");
                        var login = Console.ReadLine();
                        Console.Write("Enter your password: ");
                        var password = Console.ReadLine();
                        var librarian = context.Librarians.FirstOrDefault(l => l.Login == login && l.Password == password);
                        if (librarian != null)
                        {
                            Console.WriteLine("You are logged in");
                            Console.WriteLine("List of readers:");
                            foreach (var r in context.Readers)
                            {
                                Console.WriteLine(r.FirstName + " " + r.LastName);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid login or password");
                        }
                        break;
                    case "2":
                        Console.WriteLine("Librarian registration");
                        Console.Write("Enter your login: ");
                        var newLogin = Console.ReadLine();
                        Console.Write("Enter your password: ");
                        var newPassword = Console.ReadLine();
                        var newLibrarian = new Librarian
                        {
                            Login = newLogin,
                            Password = newPassword
                        };
                        context.Librarians.Add(newLibrarian);
                        context.SaveChanges();
                        Console.WriteLine("You are registered");
                        
                        break;
                    case "3":
                        Console.WriteLine("Reader login");
                        Console.Write("Enter your login: ");
                        var readerLogin = Console.ReadLine();
                        Console.Write("Enter your password: ");
                        var readerPassword = Console.ReadLine();
                        var reader = context.Readers.FirstOrDefault(r => r.Login == readerLogin && r.Password == readerPassword);
                        if (reader != null)
                        {
                            Console.WriteLine("You are logged in");
                            Console.WriteLine("List of books:");
                            foreach (var b in context.Books)
                            {
                                Console.WriteLine(b.Title);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid login or password");
                        }
                        break;
                    case "4":
                        Console.WriteLine("Reader registration");
                        Console.Write("Enter your login: ");
                        var newReaderLogin = Console.ReadLine();
                        Console.Write("Enter your password: ");
                        var newReaderPassword = Console.ReadLine();
                        Console.Write("Enter your first name: ");
                        var newReaderFirstName = Console.ReadLine();
                        Console.Write("Enter your last name: ");
                        var newReaderLastName = Console.ReadLine();
                        Console.Write("Enter your document number: ");
                        var documentNumber = Console.ReadLine();
                        Console.Write("Enter your document type: ");
                        var documentType = Console.ReadLine();

                        var newReader = new Reader
                        {
                            Login = newReaderLogin,
                            Password = newReaderPassword,
                            FirstName = newReaderFirstName,
                            LastName = newReaderLastName,
                            DocumentNumber = documentNumber,
                            DocumentTypeId = int.Parse(documentType)
                        };
                        context.Readers.Add(newReader);
                        context.SaveChanges();
                        Console.WriteLine("You are registered");
                        break;
                    case "0":
                        return;
                }

            }

        }
    }
}
