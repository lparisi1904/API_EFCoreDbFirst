using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API_EFCoreDbFirst.Models;

public partial class Book
{
    public Book()
    {
        BookAuthors = new HashSet<BookAuthors>();
    }

    [Key]
    public long Id { get; set; }

    public string Title { get; set; } = null!;

    public long CategoryId { get; set; }

    public long PublisherId { get; set; }

    public virtual BookCategory Category { get; set; } = null!;

    public virtual Publisher Publisher { get; set; } = null!;

    public virtual ICollection<BookAuthors> BookAuthors { get; set; } 
}
