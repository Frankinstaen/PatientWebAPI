using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PatientWebAPI.DTO.PersonDTO;
using PatientWebAPI.Repository;

namespace PatientWebAPI.Controllers
{
    [ApiController]
    [Route("api/persons")]
    public class PersonController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<PersonController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public PersonController(IMapper mapper, ILogger<PersonController> logger, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Получить список обьектов Person
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _unitOfWork.PersonRepository.All();
            var mapper = _mapper.Map<IEnumerable<PersonGetDTO>>(result);
            return Ok(mapper);
        }

        /// <summary>
        /// Получить обьект Person по Id
        /// </summary>
        [HttpGet("{Id:guid}")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            var result = await _unitOfWork.PersonRepository.GetById(Id);
            var mapper = _mapper.Map<PersonGetDTO>(result);
            return Ok(mapper);
        }
    }
}
