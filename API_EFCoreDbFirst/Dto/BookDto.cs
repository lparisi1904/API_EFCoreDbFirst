using API_EFCoreDbFirst.Dto;

namespace API_EFCoreDbFirst.Dto
{
    public class BookDto
    {
        public long Id { get; set; }
        public string Title { get; set; }

        public PublisherDto Publisher { get; set; }
        public ICollection<AuthorDto> Authors { get; set; }
    }
}
