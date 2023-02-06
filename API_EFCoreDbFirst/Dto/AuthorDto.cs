namespace API_EFCoreDbFirst.Dto
{
    public class AuthorDto
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public AuthorContactDto AuthorContact { get; set; }
    }
}
