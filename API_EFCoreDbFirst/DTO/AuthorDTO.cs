namespace API_EFCoreDbFirst.Dto
{
    public record AuthorDTO 
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public AuthorContactDTO AuthorContact { get; set; }
    }
}
