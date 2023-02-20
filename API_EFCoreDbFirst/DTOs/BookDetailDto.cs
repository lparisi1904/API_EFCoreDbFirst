using API_EFCoreDbFirst.Models;

namespace API_EFCoreDbFirst.DTOs
{
    public record class BookDetailDto
    {
        public long Id { get; init; } = default!;
        public string Title { get; init; } = default!;

        public string Publisher { get; init; } = default!;
        public string AuthorName { get; init; } = default!;
        public string Category { get; init; } = default!;
    }

}
