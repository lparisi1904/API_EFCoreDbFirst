using System;
using System.Collections.Generic;

namespace API_EFCoreDbFirst.Models;

public partial class Book
{

    public Book()
    {
        BookAuthors = new List<BookAuthors>();
    }

    public long Id { get; set; }

    public string Title { get; set; } = null!;

    public long CategoryId { get; set; }

    public long PublisherId { get; set; }

    public virtual BookCategory Category { get; set; } = null!;

    public virtual Publisher Publisher { get; set; } = null!;

    public virtual ICollection<BookAuthors> BookAuthors { get; } = new List<BookAuthors>();
}
