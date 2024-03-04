using System;
using System.Collections.Generic;

namespace DBLibraryAccess.Model;

public partial class AuthorBook
{
    public int? AuthorId { get; set; }

    public int? BookId { get; set; }

    public virtual Author? Author { get; set; }

    public virtual Book? Book { get; set; }
}
