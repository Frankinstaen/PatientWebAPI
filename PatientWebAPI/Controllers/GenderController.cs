using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PatientWebAPI.DTO.ActiveDTO;
using PatientWebAPI.DTO.GenderDTO;
using PatientWebAPI.Repository;

namespace PatientWebAPI.Controllers
{
    [ApiController]
    [Route("api/genders")]
    public class GenderController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<GenderController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public GenderController(IMapper mapper, ILogger<GenderController> logger, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Получить данные справочника Gender 
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _unitOfWork.GenderRepository.All();
            var mapped = _mapper.Map<IEnumerable<GenderGetDTO>>(result);
            return Ok(mapped);
        }

        /// <summary>
        /// Получить запись справочника Gender по Id
        /// </summary>
        [HttpGet("{Id:guid}")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            var result = await _unitOfWork.GenderRepository.GetById(Id);
            var mapped = _mapper.Map<GenderGetDTO>(result);
            return Ok(mapped);
        }
    }
}
