using API_EFCoreDbFirst.Models;
using System.Security.Cryptography;
using System.Collections;
using API_EFCoreDbFirst.DTOs;

namespace API_EFCoreDbFirst.Utilities.MapToDto
{
    public record class AuthorMapperDto
    {
        public static AuthorDetailsDto MapAuthorToDto
        (Author author, List<BookDetailDto> book) => new() {
            Id = author.Id,
            Name = author.Name,
            Address = author.AuthorContact.Address,
            ContactNumber = author.AuthorContact.ContactNumber,
            Books = book.Select(p => new BookDetailDto
            {
                Title = p.Title,
                AuthorName = p.AuthorName,
                Category = p.Category,
                Publisher = p.Publisher
            }).ToList()
            //.Where(b=> b.Id == author.Id).ToList()
        };
    }
}