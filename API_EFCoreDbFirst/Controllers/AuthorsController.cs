using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_EFCoreDbFirst.Repository;
using API_EFCoreDbFirst.Models;
using API_EFCoreDbFirst.Dto;

namespace API_EFCoreDbFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IDataRepository<Author, AuthorDto> _repository;
        
        public AuthorsController(IDataRepository<Author, AuthorDto> repository) 
            => _repository = repository;

        [HttpGet]
        public IActionResult Get()
        {
            var authors = _repository.GetAll();

            if (authors == null)
            {
                return NotFound("Authors not found.");
            }

            return Ok(authors);
        }

        [HttpGet("{id}", Name = "GetAuthor")]
        public ActionResult Get(long id)
        {
            var author = _repository.Get(id);

            if (author == null)
                return NotFound();

            return Ok(author);
        }

        // POST: api/authors
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Author author)
        {
            if (author is null)
                return NotFound("Autore non trovato..");

            if (!ModelState.IsValid)
                return BadRequest();

           await _repository.Add(author);

            // dobbiamo restituire 201 (Creato) invece della semplice risposta 200 OK.
            return CreatedAtAction("GetAuthor", new { id = author.Id }, author);
           
            // oppure CreatedAtRoute...
            //return CreatedAtRoute("GetAuthor", new { Id = author.Id }, null);
        }

        // PUT: api/Authors/1
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Author author)
        {
            if (author is null)
                return BadRequest();

            var authorToUpdate = _repository.Get(id);

            if (authorToUpdate == null)
                return NotFound("Autore non trovato..");

            if (!ModelState.IsValid)
                return BadRequest();

            await _repository.Update(authorToUpdate, author);

            return NoContent();
        }








    }
}
