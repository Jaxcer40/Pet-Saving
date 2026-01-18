using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using api.Data;
using api.Mappers;
using api.Dtos.Patient;

namespace api.Controllers
{
    [Route("api/patient")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public PatientController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var patients= _context.Patients.ToList()
            .Select(s=>s.ToReadPatientDto());
           

            return Ok(patients);
        
        }

        [HttpGet ("{Id}")]
        public IActionResult GetById([FromRoute] int Id)
        {
            var patient = _context.Patients.Find(Id);
            
            if(patient== null)
            {
                return NotFound();
            }

            return Ok(patient.ToReadPatientDto());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreatePatientDto patientDto)
        {
            var patientModel = patientDto.ToPatientFromCreateDto();
            _context.Patients.Add(patientModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById),new {id = patientModel.Id}, patientModel.ToReadPatientDto());
        }

    }
}