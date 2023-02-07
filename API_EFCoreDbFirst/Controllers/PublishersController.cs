using API_EFCoreDbFirst.Dto;
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
        private readonly IDataRepository<Publisher, PublisherDto> _repository;

        public PublishersController(IDataRepository<Publisher, PublisherDto> repository)  
            => _repository = repository;

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var publisher = _repository.GetAsync(id);

                if (publisher == null)
                    return NotFound("L'Editore non può essere trovato..");

                await _repository.DeleteAsync(publisher);

                return Ok(publisher);
            }
            catch (WebException ex)
            {
                throw new Exception($"Un errore è avvenuto. Tipo di errore: {ex.Message}");
            }
        }
    }
}
