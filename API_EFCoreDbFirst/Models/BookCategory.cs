using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API_EFCoreDbFirst.Models;

public partial class BookCategory
{
    public BookCategory()
    {
        Book= new HashSet<Book>();
    }

    [Key]
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    //public virtual ICollection<Book> Books { get; } = new List<Book>();

    public virtual ICollection<Book> Book { get; set; }
}
