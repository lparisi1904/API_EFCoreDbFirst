﻿using API_EFCoreDbFirst.Dto;
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
                throw new Exception($"Un errore è avvenuto. Tipo di errore: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Book>> AddBook(Book book)
        {
            try
            {
                await _db.Add(book);

                return CreatedAtAction("GetBook", new { id = book.Id }, book);
            }
            catch (WebException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{book.Title} non puo essere aggiunto.");
            }
        }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateBook(int id, Book book)
        //{
        //    try
        //    {
        //        if (id != book.Id)
        //            return BadRequest();

        //        await _db.Update(book, book);

        //        return NoContent();
        //    }
        //    catch (WebException)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, $"{book.Title} non  puo essere aggiornato");
        //    }
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteBook(int id, Book book)
        //{
        //    try
        //    {
        //         _db.Get(id);

        //        //(bool status, string message) = await _db.Delete(book);
        //        await _db.Delete(book);

        //        return StatusCode(StatusCodes.Status200OK, book);
        //    }
        //    catch (WebException)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, $"{book.Title} non  puo essere aggiornato");
        //    }
        //}
    }
}
