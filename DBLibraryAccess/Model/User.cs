using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBLibraryAccess.Model;

public partial class User
{
    public int Id { get; set; }
    public string? Login { get; set; }

    public string? Password { get; set; }

    public string? Email { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public int? DocumentTypeId { get; set; }

    public string? DocumentNumber { get; set; }

    public virtual DocumentType? DocumentType { get; set; }

    public int? UserRoleId { get; set; }

    public virtual UserRole? UserRole { get; set; }

    public virtual List<UserBook> UserBooks { get; set; } = new List<UserBook>();

    [NotMapped]
    public virtual ICollection<Book?> Books => UserBooks.Select(x => x.Book).ToList();
}
