using API_EFCoreDbFirst.DTOs;
using API_EFCoreDbFirst.Models;
using API_EFCoreDbFirst.Repository;
using API_EFCoreDbFirst.Utilities.MapToDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API_EFCoreDbFirst.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IService<Book, BookDetailDto> _db;

        // DI
        public BooksController(IService<Book, BookDetailDto> repository)
            => _db = repository;


        //// GET: api/Books/5
        //[HttpGet("{id}", Name = "GetBook")]
        //public async Task<ActionResult> GetById(int id)
        //{
        //    try
        //    {
        //        var book = await _db.GetById(id);

        //        if (book is null)
        //            return NotFound();

        //        return Ok(book);
        //    }
        //    catch (WebException ex)
        //    {
        //        throw new Exception($"Un errore è avvenuto. Tipo di errore: > {ex.Message}");
        //    }
        //}


        // GET: api/Authors/5
        [HttpGet("{id}", Name = "GetBookDto")]
        public async Task<ActionResult> GetBookDetails(long id)
        {
            var author = await _db.GetDetailsDto(id);
            if (author == null)
            {
                return NotFound("Author not found.");
            }

            return Ok(author);
        }


        [HttpGet]
        public ActionResult GetBooks()
        {
            try
            {
                var books = _db.GetAll();

                if (books == null)
                    return NotFound("Libri non presenti in archivio.");

                return Ok(books);
            }
            catch (WebException ex)
            {
                throw new Exception($"Un errore è avvenuto. Tipo di errore: > {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Book>> AddBook(Book book)
        {
            try
            {
                await _db.Add(book);

                return CreatedAtAction(nameof(GetBookDetails), new { id = book.Id }, book);
            }
            catch (WebException ex)
            {
                throw new Exception($"Un errore è avvenuto. Tipo di errore: > {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBook(long id, Book book)
        {
            try
            {
                Book dbBook = await _db.Update(id, book);

                if (book == null)
                    return BadRequest();

                return NoContent();
            }
            catch (WebException ex)
            {
                throw new Exception($"Un errore è avvenuto. Tipo di errore: > {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(long id)
        {
            try
            {
                var dbBook = _db.GetById(id);

                (bool status, string message) = await _db.Delete(id);

                if (status == false)
                    return BadRequest(message);

                return NoContent();
            }
            catch (WebException ex)
            {
                throw new Exception($"Un errore è avvenuto. Tipo di errore: > {ex.Message}");
            }
        }
    }
}