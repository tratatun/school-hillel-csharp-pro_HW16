using System;
using System.Collections.Generic;

namespace DBLibraryAccess.Model;

public partial class Librarian
{
    public int Id { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public string? Email { get; set; }
}
