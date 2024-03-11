using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLibraryAccess.Model
{
    public partial class UserBook
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int BookId { get; set; }

        public virtual User? User { get; set; }

        public virtual Book? Book { get; set; }

        public DateTime? TookDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        public string? Comment { get; set; }

        public override string ToString()
        {
            return $"{User?.FirstName} {User?.LastName} - {Book} - TookDate: {TookDate} - ReturnDate: {ReturnDate}";
        }
    }
}
