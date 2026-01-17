using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using api.Data;
using api.Mappers;

namespace api.Controllers
{
    [Route("api/Admission")]
    [ApiController]
    public class AdmissionController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public AdmissionController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var admissions= _context.Admissions.ToList();
           

            return Ok(admissions);
        
        }

        [HttpGet ("{Id}")]
        public IActionResult GetById([FromRoute] int Id)
        {
            var admission = _context.Admissions.Find(Id);
            
            if(admission== null)
            {
                return NotFound();
            }

            return Ok(admission);
        }

    }
}