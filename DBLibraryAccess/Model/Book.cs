using System;
using System.Collections.Generic;

namespace DBLibraryAccess.Model;

public partial class Book
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public int? PublisherCode { get; set; }

    public int? PublicationYear { get; set; }

    public string? Country { get; set; }

    public string? City { get; set; }

    public virtual PublisherCode? PublisherCodeNavigation { get; set; }
}
