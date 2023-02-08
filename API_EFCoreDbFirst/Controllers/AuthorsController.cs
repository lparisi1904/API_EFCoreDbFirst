﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_EFCoreDbFirst.Repository;
using API_EFCoreDbFirst.Models;
using API_EFCoreDbFirst.Dto;
using System.Net;

namespace API_EFCoreDbFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IDataRepository<Author> _db;
        
        // DI
        public AuthorsController(IDataRepository<Author> repository) 
            => _db = repository;


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
              throw new Exception($"Un errore è avvenuto. Tipo di errore: {ex.Message}");
            }
        }

        [HttpGet("{id}", Name = "GetAuthor")]
        public ActionResult GetAuthor(long id)
        {
            try
            {
                var author = _db.GetAsync(id);

                if (author == null)
                    return NotFound();

                return Ok(author);
            }
            catch (WebException ex)
            {
                throw new Exception($"Un errore è avvenuto. Tipo di errore: {ex.Message}");
            }
        }

        // POST: api/GetBook
        [HttpPost]
        public async Task<ActionResult> AddAuthor([FromBody] Author author)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

               await _db.AddAsync(author);
                // dobbiamo restituire 201 (Creato) invece della semplice risposta 200 OK.
                return CreatedAtAction(nameof(GetAuthor), new { id = author.Id }, author);
                // oppure con CreatedAtRoute...
                //return CreatedAtRoute("GetAuthor", new { Id = author.Id }, null);
            }
            catch (WebException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{author.Name} could not be added.");
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
                var authorToUpdate = _db.GetAsync(id);

                if (!ModelState.IsValid)
                    return BadRequest();

                await _db.UpdateAsync(authorToUpdate, author);

                return NoContent();

            }
            catch (WebException ex)
            {
                throw new Exception($"Un errore è avvenuto. Tipo di errore: {ex.Message}");
            }
        }
    }
}
