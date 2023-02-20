using API_EFCoreDbFirst.DTOs;
using API_EFCoreDbFirst.Models;
using API_EFCoreDbFirst.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API_EFCoreDbFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly IService<Publisher, PublisherDto> _db;

        public PublishersController(IService<Publisher, PublisherDto> repository)  
            => _db = repository;

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var publisher = _db.GetById(id);

                if (publisher == null)
                    return NotFound("L'editore non può essere trovato..");

                await _db.Delete(publisher.Id);

                return NoContent();
            }
            catch (WebException ex)
            {
                throw new Exception($"Un errore è avvenuto -> Tipo di errore: {ex.Message}");
            }
        }
    }
}
