using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API_EFCoreDbFirst.Models;

public partial class AuthorContact
{
    [Key]
    public long AuthorId { get; set; }

    public string ContactNumber { get; set; } = null!;

    public string? Address { get; set; }

    public virtual Author Author { get; set; } = null!;
}
