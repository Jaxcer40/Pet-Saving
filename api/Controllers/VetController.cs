using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using api.Data;
using api.Mappers;
using api.Dtos.Vet;
using System.Data;

namespace api.Controllers
{
    [Route("api/vet")]
    [ApiController]
    public class VetController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public VetController(ApplicationDBContext context)
        {
            _context=context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var vets= _context.Vets.ToList()
            .Select(s=>s.ToReadVetDto());
           
            return Ok(vets);
        }        

        [HttpGet("{Id}")]
        public IActionResult GetById([FromRoute] int Id)
        {
            var vet= _context.Vets.Find(Id);

            if (vet == null)
            {
                return NotFound();
            }

            return Ok(vet.ToReadVetDto());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateVetDto vetDto)
        {
            var vetModel= vetDto.ToVetFromCreateDto();
            _context.Vets.Add(vetModel);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new {id=vetModel.Id}, vetModel.ToReadVetDto());
        }

        [HttpPatch("{Id}")]
        public IActionResult Patch(int id, [FromBody] UpdateVetDton updateVet)
        {
            var vetModel=_context.Vets.FirstOrDefault(x=>x.Id==id);

            if (vetModel == null)
            {
                return NotFound();
            }

            if(updateVet.FirstName!=null)
                vetModel.FirstName= updateVet.FirstName;
            
            if(updateVet.LastName!=null)
                vetModel.LastName= updateVet.LastName;
            
            if(updateVet.Email!=null)
                vetModel.Email= updateVet.Email;
            
            if(updateVet.PhoneNumber!=null)
                vetModel.PhoneNumber= updateVet.PhoneNumber;
            
            if(updateVet.Specialization!=null)
                vetModel.Specialization= updateVet.Specialization;
            
            if(updateVet.BirthDate.HasValue)
                vetModel.BirthDate= updateVet.BirthDate.Value;
            
            if(updateVet.HireDate.HasValue)
                vetModel.HireDate= updateVet.HireDate.Value;    
            
            if(updateVet.Activity!=null)
                vetModel.Activity= updateVet.Activity;

            _context.SaveChanges();
            return Ok(vetModel.ToReadVetDto());
        }
    }
}