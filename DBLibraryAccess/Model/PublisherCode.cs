using System;
using System.Collections.Generic;

namespace DBLibraryAccess.Model;

public partial class PublisherCode
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
