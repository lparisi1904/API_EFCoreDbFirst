using API_EFCoreDbFirst.Dto;
using API_EFCoreDbFirst.Models;
using API_EFCoreDbFirst.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API_EFCoreDbFirst.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IService<Book> _db;

        // DI...
        public BooksController(IService<Book> dataRepository)
            => _db = dataRepository;

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetBook(int id)
        {
            try
            {   
                var book = await _db.Get(id);

                if (book == null)
                    return NotFound();

                return Ok(book);
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

                return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
            }
            catch (WebException ex)
            {
                throw new Exception($"Un errore è avvenuto. Tipo di errore: > {ex.Message}");
            }
        }

        //[HttpPut("{id}")]
        //public async Task<ActionResult> UpdateBook(Book book)
        //{
        //    try
        //    {
        //        Book dbBook = await _db.Update(book);

        //        if (dbAuthor == null)
        //            return BadRequest();

        //        return NoContent();
        //    }
        //    catch (WebException ex)
        //    {
        //        throw new Exception($"Un errore è avvenuto. Tipo di errore: > {ex.Message}");
        //    }
        //}

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(long id) 
        {
            try {
                var dbBook = _db.Get(id);

                (bool status, string message) = await _db.Delete(id);

                if (status == false)
                    return BadRequest(message);

                return NoContent();
            }
            catch (WebException ex) {
                throw new Exception($"Un errore è avvenuto. Tipo di errore: > {ex.Message}");
            }
        }
    }
}
