using API_EFCoreDbFirst.Models;
using System.Security.Cryptography;
using System.Collections;
using API_EFCoreDbFirst.DTOs;

namespace API_EFCoreDbFirst.Utilities.MapToDto
{
    public record class BookMapperDto
    {
        public static BookDetailDto MapBookToDto
        (Book book, Author author) => new()  {
            Id = book.Id,
            Title = book.Title,
            AuthorName = author.Name ?? "Autore NoN presente",
            Category = book.Category.Name,
            Publisher = book.Publisher.Name
        };
    }
}