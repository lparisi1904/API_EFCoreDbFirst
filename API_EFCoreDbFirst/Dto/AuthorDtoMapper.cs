using API_EFCoreDbFirst.Models;
using API_EFCoreDbFirst.Dto;

namespace API_EFCoreDbFirst.Dto
{
    public static class AuthorDtoMapper 
    {
        public static AuthorDto MapToDto(Author author)
        {
            return new AuthorDto()
            {
                Id = author.Id,
                Name = author.Name,

                AuthorContact = new AuthorContactDto()
                {
                    AuthorId = author.Id,
                    Address = author.AuthorContact.Address,
                    ContactNumber = author.AuthorContact.ContactNumber
                }
            };
        }
    }
}
