using API_EFCoreDbFirst.Dto;
using API_EFCoreDbFirst.Models;
using API_EFCoreDbFirst.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_EFCoreDbFirst.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IDataRepository<Book, BookDto> _dataRepository;

        // DI...
        public BooksController(IDataRepository<Book, BookDto> dataRepository)
            => _dataRepository = dataRepository;

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var book = await _dataRepository.Get(id);

            if (book == null)
                return NotFound("Libro non trovato..");

            return Ok(book);
        }
    }
}
