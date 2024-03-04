using System;
using System.Collections.Generic;

namespace DBLibraryAccess.Model;

public partial class DocumentType
{
    public int Id { get; set; }

    public string? Type { get; set; }

    public virtual ICollection<Reader> Readers { get; set; } = new List<Reader>();
}
