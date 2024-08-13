using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using PatientWebAPI.DTO.PatientDTO;
using PatientWebAPI.Entity;
using PatientWebAPI.Repository;
using System.Numerics;
using System.Security.Claims;

namespace PatientWebAPI.Controllers
{
    [ApiController]
    [Route("api/patients")]
    public class PatientController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<PatientController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public PatientController(IMapper mapper, ILogger<PatientController> logger, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Получить список обьектов Patient
        /// </summary>
        [HttpGet]
        [EnableQuery]
        public async Task<IActionResult> GetAll()
        {
            var patients = await _unitOfWork.PatientRepository.All();
            var result = _mapper.Map<IEnumerable<PatientDTO>>(patients);
            return Ok(result);
        }

        /// <summary>
        /// Получить обьект Patient по Id
        /// </summary>
        [HttpGet("{Id:guid}")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            var patient = await _unitOfWork.PatientRepository.GetById(Id);
            var result = _mapper.Map<PatientDTO>(patient);
            return Ok(result);
        }

        /// <summary>
        /// Создать обьект Patient
        /// </summary>
        [HttpPost] 
        public async Task<IActionResult> Create(PatientAddDTO patientAddDTO)
        {
            if (ModelState.IsValid)
            {
                var patient = _mapper.Map<Patient>(patientAddDTO);
                try
                {
                    patient.Gender = new Gender();
                    patient.Gender = await _unitOfWork.GenderRepository.GetById((Guid)patientAddDTO.GenderId);
                    patient.GenderId = (Guid)patientAddDTO.GenderId;
                    patient.Active = new Active();
                    patient.Active = await _unitOfWork.ActiveRepository.GetById((Guid)patientAddDTO.ActiveId);
                    patient.ActiveId = (Guid)patientAddDTO.ActiveId;
                }
                catch (Exception ex) {

                }
                var result = await _unitOfWork.PatientRepository.Add(patient); 
                await _unitOfWork.CompleteAsync();
                var mapped = _mapper.Map<PatientDTO>(result);

                return Ok(mapped);
            }

            return new JsonResult("Error while adding Patient") { StatusCode = 500 };
        }

        /// <summary>
        /// Изменить обьект Patient по Id
        /// </summary>
        [HttpPut("{Id:guid}")]
        public async Task<IActionResult> Update(Guid Id, PatientAddDTO patient)
        {
            var obj = await _unitOfWork.PatientRepository.GetById(Id);

            obj.Name.Use = String.IsNullOrEmpty(patient.Name.Use) ? obj.Name.Use : patient.Name.Use;
            obj.Name.Family = String.IsNullOrEmpty(patient.Name?.Family) ? obj.Name.Family : patient.Name.Family;
            obj.Gender = patient.GenderId == null ? obj.Gender : await _unitOfWork.GenderRepository.GetById((Guid)patient.GenderId);
            obj.GenderId = obj.Gender.Id;
            obj.BirthDate = patient.BirthDate.Equals(obj.BirthDate) ? obj.BirthDate : patient.BirthDate;
            obj.Active = patient.ActiveId == null ? obj.Active : await _unitOfWork.ActiveRepository.GetById((Guid)patient.ActiveId);
            obj.ActiveId = obj.Active.Id;
            
            if (patient.Name.Given != null)
                obj.Name.Given = (patient.Name.Given.Count > 0 ? _mapper.Map<List<Person>>(patient.Name.Given) : obj.Name.Given);

            await _unitOfWork.PatientRepository.Upsert(obj);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        /// <summary>
        /// Удалить обьект Patient по Id
        /// </summary>
        [HttpDelete("{Id:guid}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var patient = await _unitOfWork.PatientRepository.GetById(Id);
            if (patient == null)
            {
                return NotFound();
            }

            await _unitOfWork.PatientRepository.Delete(patient);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }
    }
}
