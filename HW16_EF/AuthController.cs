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
    class AuthController
    {
        private readonly ILibraryModelContext context;
        private User? currentUser = null;
        public bool IsLoggedIn { get { return currentUser != null; } }
        public AuthController(ILibraryModelContext userRepository)
        {
            this.context = userRepository;
        }

        public bool Login(string username, string password)
        {
            currentUser = context.Users.FirstOrDefault(u => u.Login != null && u.Login.ToLower() == username.ToLower());
            if (currentUser != null && currentUser.Password == password)
            {
                return true;
            }
            else
            {
                Logout();
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
