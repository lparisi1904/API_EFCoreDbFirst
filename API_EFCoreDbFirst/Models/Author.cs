using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API_EFCoreDbFirst.Models;

public partial class Author
{
    public Author()
    {
        BookAuthors = new HashSet<BookAuthors>();
    }

    [Key]
    public long Id { get; set; }

    public string Name { get; set; } = null!;
    public string Nam22e { get; set; } = null!;

    public virtual AuthorContact? AuthorContact { get; set; }

    public virtual ICollection<BookAuthors> BookAuthors { get; set; } 
}