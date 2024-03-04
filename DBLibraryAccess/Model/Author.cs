using System;
using System.Collections.Generic;

namespace DBLibraryAccess.Model;

public partial class Author
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? AliasName { get; set; }

    public DateTime? DateOfBirth { get; set; }
}
