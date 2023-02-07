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

        public AuthorsController(IDataRepository<Author, AuthorDto> dataRepository)
        {
            _repository = dataRepository;
        }

        [HttpGet]


    }
}
