using System.ComponentModel.DataAnnotations;

namespace API_EFCoreDbFirst.Models
{
    public partial class BookAuthors
    {
        [Key]
        public long BookId { get; set; }
        public long AuthorId { get; set; }

        public virtual Author Author { get; set; }
        public virtual Book Book { get; set; }
    }
}
