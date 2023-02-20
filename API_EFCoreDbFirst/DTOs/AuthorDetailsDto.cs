using API_EFCoreDbFirst.Models;

namespace API_EFCoreDbFirst.DTOs
{
    public record AuthorDetailsDto
    {
        public long Id { get; init; } = default!;

        public string Name { get; init; } = default!;
        public string ContactNumber { get; init; } = default!;
        public string Address { get; init; } = default!;

        public List<BookDetailDto> Books { get; set; }

    }
}
