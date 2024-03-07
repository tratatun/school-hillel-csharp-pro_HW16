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

            var libraryController = new LibraryController(context);
            libraryController.ShowLoginMenu();
        }
    }
}
