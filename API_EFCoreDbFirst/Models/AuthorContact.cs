using System;
using System.Collections.Generic;

namespace API_EFCoreDbFirst.Models;

public partial class AuthorContact
{
    public long AuthorId { get; set; }

    public string ContactNumber { get; set; } = null!;

    public string? Address { get; set; }

    public virtual Author Author { get; set; } = null!;
}
