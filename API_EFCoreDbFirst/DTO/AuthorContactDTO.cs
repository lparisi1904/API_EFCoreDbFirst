namespace API_EFCoreDbFirst.Dto
{
    public record AuthorContactDTO 
    {
        public long AuthorId { get; set; }

        public string ContactNumber { get; set; }

        public string Address { get; set; }
    }
}