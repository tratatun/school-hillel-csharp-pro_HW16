using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBLibraryAccess.Model;

public partial class Author
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? AliasName { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public virtual List<AuthorBook> AuthorBooks { get; set; } = new List<AuthorBook>();

    [NotMapped]
    public virtual ICollection<Book?> Books => AuthorBooks.Select(x => x.Book).ToList();
    
    public bool IsComplyWith(string? search)
    {
        if (search == null)
        {
            return true;
        }
        return FirstName?.Contains(search, StringComparison.OrdinalIgnoreCase) == true
            || LastName?.Contains(search, StringComparison.OrdinalIgnoreCase) == true
            || AliasName?.Contains(search, StringComparison.OrdinalIgnoreCase) == true;
    }

    public override string ToString()
    {
        return $"{FirstName} {LastName}";
    }
}
