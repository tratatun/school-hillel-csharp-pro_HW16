using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLibraryAccess.Model
{
    public partial class UserRole
    {
        public int Id { get; set; }

        public string? Role { get; set; }

        public virtual ICollection<User> Users { get; set; } = new List<User>();

    }
}
