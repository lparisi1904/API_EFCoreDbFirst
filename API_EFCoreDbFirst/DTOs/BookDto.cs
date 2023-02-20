namespace API_EFCoreDbFirst.DTOs
{
    public record BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
    }
}
