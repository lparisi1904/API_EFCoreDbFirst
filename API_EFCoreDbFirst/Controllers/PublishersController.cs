using API_EFCoreDbFirst.Dto;
using API_EFCoreDbFirst.Models;
using API_EFCoreDbFirst.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            var publisher = _repository.Get(id);

            if (publisher == null)
                return NotFound("L'Editore non può essere trovato..");

            await _repository.Delete(publisher);

            return Ok(publisher);

        }

    }
}
