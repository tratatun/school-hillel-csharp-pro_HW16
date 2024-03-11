using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBLibraryAccess.Model;

public partial class Book
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public int? PublisherCode { get; set; }

    public int? PublicationYear { get; set; }

    public string? Country { get; set; }

    public string? City { get; set; }

    public bool? IsInLibrary { get; set; }

    public virtual PublisherCode? PublisherCodeNavigation { get; set; }

    public virtual List<UserBook> UserBooks { get; set; } = new List<UserBook>();
    
    [NotMapped]
    public virtual ICollection<User?> Users => UserBooks.Select(x => x.User).ToList();

    public virtual List<AuthorBook> AuthorBooks { get; set; } = new List<AuthorBook>();
    
    [NotMapped]
    public virtual ICollection<Author?> Authors => AuthorBooks.Select(x => x.Author).ToList();

    public override string ToString()
    {
        var authors = string.Join(", ", Authors.Select(x => x ));
        return $"{Title} {authors} ({PublicationYear})";
    }
}
