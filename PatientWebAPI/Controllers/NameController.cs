using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PatientWebAPI.DTO;
using PatientWebAPI.DTO.NameDTO;
using PatientWebAPI.Repository;

namespace PatientWebAPI.Controllers
{
    [ApiController]
    [Route("api/names")]
    public class NameController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<NameController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public NameController(IMapper mapper, ILogger<NameController> logger, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Получить список обьектов Name 
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _unitOfWork.NameRepository.All();
            var mapper = _mapper.Map<IEnumerable<NameGetDTO>>(result);
            return Ok(mapper);
        }

        /// <summary>
        /// Получить обьект Name по Id
        /// </summary>
        [HttpGet("{Id:guid}")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            var result = await _unitOfWork.NameRepository.GetById(Id);
            var mapper = _mapper.Map<NameGetDTO>(result);
            return Ok(mapper);
        }
    }
}
