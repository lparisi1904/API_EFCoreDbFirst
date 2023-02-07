using API_EFCoreDbFirst.Dto;

namespace API_EFCoreDbFirst.Dto
{
    public record BookRec
    {
        public long Id { get; set; }
        public string Title { get; set; }

        public PublisherRec Publisher { get; set; }
        public ICollection<AuthorRec> Authors { get; set; }

    }
}
