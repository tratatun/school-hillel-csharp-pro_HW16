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
    class AuthSystem
    {
        private readonly ILibraryModelContext context;
        private User? currentUser = null;
        public bool IsLoggedIn { get { return currentUser != null; } }
        public AuthSystem(ILibraryModelContext userRepository)
        {
            this.context = userRepository;
        }

        public bool Login(string username, string password)
        {
            currentUser = context.Users.First(u => u.Login != null && u.Login.ToLower() == username.ToLower());
            if (currentUser != null && currentUser.Password == password)
            {
                Console.WriteLine($"Welcome, {username}!");
                return true;
            }
            else
            {
                currentUser = null;
                Console.WriteLine("Invalid username or password. Please try again.");
                return false;
            }
        }

        public User? GetCurrentUser()
        {
            context.Users.Include(u => u.UserRole).Load();
            return currentUser;
        }

        public void Logout()
        {
            currentUser = null;
        }
    }

}
