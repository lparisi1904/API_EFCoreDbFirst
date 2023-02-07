using API_EFCoreDbFirst.Models;
using API_EFCoreDbFirst.Dto;

namespace API_EFCoreDbFirst.Dto
{
    public record AuthorMapperRec 
    {
        public static AuthorRec  MapToRecord(Author author)
        {
            return new AuthorRec ()
            {
                Id = author.Id,
                Name = author.Name,

                AuthorContact = new AuthorContactRec()
                {
                    AuthorId = author.Id,
                    Address = author.AuthorContact.Address,
                    ContactNumber = author.AuthorContact.ContactNumber
                }
            };
        }
    }
}
 