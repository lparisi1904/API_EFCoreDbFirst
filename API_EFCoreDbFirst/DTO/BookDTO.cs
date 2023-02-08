using API_EFCoreDbFirst.Dto;

namespace API_EFCoreDbFirst.Dto
{
    public record BookDTO
    {
        public long Id { get; set; }
        public string Title { get; set; }

        public PublisherDTO Publisher { get; set; }
        public ICollection<AuthorDTO> Authors { get; set; }

    }
}
