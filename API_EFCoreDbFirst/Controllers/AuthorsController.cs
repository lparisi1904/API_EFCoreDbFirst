using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_EFCoreDbFirst.Repository;
using API_EFCoreDbFirst.Models;
using System.Net;
using Microsoft.EntityFrameworkCore;
using API_EFCoreDbFirst.DTOs;

namespace API_EFCoreDbFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IService<Author, AuthorDetailsDto> _db;

        // DI
        public AuthorsController(IService<Author, AuthorDetailsDto> repository)
            => _db = repository;


        // GET: api/Authors/5
        [HttpGet("{id}", Name = "GetAuthorDto")]
        public async Task<ActionResult> GetAuthorDetails(long id)
        {
            var author = await _db.GetDetailsDto(id);
            if (author == null)
            {
                return NotFound("Author not found.");
            }

            return Ok(author);
        }


        [HttpGet]
        public ActionResult GetAuthors()
        {
            try
            {
                var authors = _db.GetAll();

                if (authors == null)
                    return NotFound("Autori non presenti in archivio.");

                return Ok(authors);
            }
            catch (WebException ex)
            {
                throw new Exception($"Un errore è avvenuto. Tipo di errore: > {ex.Message}");
            }
        }

        //[HttpGet("{id}", Name = "GetAuthor")]
        //public ActionResult GetAuthor(long id)
        //{
        //    try
        //    {
        //        var author = _db.GetById(id);

        //        if (author == null)
        //            return NotFound();

        //        return Ok(author);
        //    }
        //    catch (WebException ex)
        //    {
        //        throw new Exception($"Un errore è avvenuto. Tipo di errore: {ex.Message}");
        //    }
        //}

        // POST: api/GetBook
        [HttpPost]
        public async Task<ActionResult> AddAuthor([FromBody] Author author)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                await _db.Add(author);

                // dobbiamo restituire 201 (Creato) invece della semplice risposta 200 OK.
                return CreatedAtAction(nameof(GetAuthorDetails), new { id = author.Id }, author);
                //return CreatedAtRoute("GetAuthor", new { Id = author.Id }, null);
            }
            catch (WebException ex)
            {
                throw new Exception($"Un errore è avvenuto. Tipo di errore: {ex.Message}");
            }
        }



        // PUT: api/Authors/1
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAuthor(int id, [FromBody] Author author)
        {
            try
            {
                if (author is null)
                    return NotFound();

                if (id != author.Id)
                    return BadRequest();

                var authorToUpdate = _db.GetById(id);

                if (authorToUpdate == null)
                    return NotFound();

                if (!ModelState.IsValid)
                    return BadRequest();

                await _db.Update(id, author);

                return NoContent();
            }
            catch (WebException ex)
            {
                throw new Exception($"Un errore è avvenuto. Tipo di errore: > {ex.Message}");
            }
        }
    }
}

