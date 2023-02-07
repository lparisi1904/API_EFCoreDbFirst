namespace API_EFCoreDbFirst.Dto
{
    public record AuthorRec 
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public AuthorContactRec AuthorContact { get; set; }
    }
}
