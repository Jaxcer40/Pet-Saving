using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using api.Data;

namespace api.Controllers
{
    [Route("api/status")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public StatusController(ApplicationDBContext context)
        {
            _context=context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var statuses=_context.Statuses.ToList();

            return Ok(statuses);
        }

        [HttpGet ("{Id}")]
        public IActionResult GetById([FromRoute] int Id)
        {
            var status = _context.Statuses.Find(Id);
            
            if(status== null)
            {
                return NotFound();
            }

            return Ok(status);
        }
    }
}
