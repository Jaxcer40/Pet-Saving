using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using Microsoft.AspNetCore.Mvc;
using api.Mappers;
using api.Dtos.Client;
using System.Data;

namespace api.Controllers
{
    [Route("api/client")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public ClientController(ApplicationDBContext context)
        {
            _context= context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var clients= _context.Clients.ToList()
            .Select(s=>s.ToReadClientDto());

            return Ok(clients);
        }

        [HttpGet("{Id}")]
        public IActionResult GetById([FromRoute] int Id)
        {
            var client= _context.Clients.Find(Id);

            if (client == null)
            {
                return NotFound();
            }

            return Ok(client.ToReadClientDto());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateClientDto clientDto)
        {
            var clientModel = clientDto.ToClientFromCreateDto();
            _context.Clients.Add(clientModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new {id=clientModel.Id}, clientModel.ToReadClientDto());
        }

        [HttpPatch("{Id}")]
        public IActionResult Patch(int id, [FromBody]UpdateClientDto updateDto)
        {
            var clientModel= _context.Clients.FirstOrDefault(x=>x.Id==id);

            if (clientModel == null)
            {
                return NotFound();
            }

            if(updateDto.FirstName!=null)
                clientModel.FirstName=updateDto.FirstName;
            
            if(updateDto.LastName!=null)
                clientModel.LastName=updateDto.LastName;
            
            if(updateDto.Email!=null)
                clientModel.Email=updateDto.Email;

            if(updateDto.PhoneNumber!=null)
                clientModel.PhoneNumber=updateDto.PhoneNumber;

            if(updateDto.Address!=null)
                clientModel.Address=updateDto.Address;
            
            if(updateDto.BirthDate.HasValue)
                clientModel.BirthDate=updateDto.BirthDate.Value;
            
            if(updateDto.RegistrationDate.HasValue)
                clientModel.RegistrationDate=updateDto.RegistrationDate.Value;

            if(updateDto.EmergencyContactName!=null)
                clientModel.EmergencyContactName=updateDto.EmergencyContactName;
            
            if(updateDto.EmergencyContactPhone!=null)
                clientModel.EmergencyContactPhone=updateDto.EmergencyContactPhone;
            
            _context.SaveChanges();

            return Ok(clientModel.ToReadClientDto());
        }
    }
}