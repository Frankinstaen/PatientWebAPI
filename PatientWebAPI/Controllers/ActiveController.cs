using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PatientWebAPI.DTO.ActiveDTO;
using PatientWebAPI.Repository;

namespace PatientWebAPI.Controllers
{
    [ApiController]
    [Route("api/actives")]
    public class ActiveController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<ActiveController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public ActiveController(IMapper mapper, ILogger<ActiveController> logger, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// Получить данные справочника Active 
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _unitOfWork.ActiveRepository.All();
            var mapped = _mapper.Map<IEnumerable<ActiveGetDTO>>(result);
            return Ok(mapped);
        }
        /// <summary>
        /// Получить запись справочника Active по Id
        /// </summary>
        [HttpGet("{Id:guid}")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            var result = await _unitOfWork.ActiveRepository.GetById(Id);
            var mapped = _mapper.Map<ActiveGetDTO>(result);
            return Ok(mapped);
        }
    }
}
