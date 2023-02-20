namespace API_EFCoreDbFirst.DTOs
{
    public record AuthorContactDto
    {
        public long AuthorId { get; init; } = default!;

        public string ContactNumber { get; init; } = default!;

        public string Address { get; init; } = default!;
    }
}