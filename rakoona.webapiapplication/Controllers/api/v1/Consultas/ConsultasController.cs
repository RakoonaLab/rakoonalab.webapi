using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rakoona.webapiapplication.Context;
using rakoona.webapiapplication.Entities.Models.Consultas;

namespace rakoona.webapi.Controllers.api.v1.Consultas
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ConsultasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Consultas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConsultaBase>>> GetConsulta()
        {
            return await _context.Consulta.ToListAsync();
        }

        // GET: api/Consultas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConsultaBase>> GetConsultaBase(int id)
        {
            var consultaBase = await _context.Consulta.FindAsync(id);

            if (consultaBase == null)
            {
                return NotFound();
            }

            return consultaBase;
        }

        // PUT: api/Consultas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConsultaBase(int id, ConsultaBase consultaBase)
        {
            if (id != consultaBase.Id)
            {
                return BadRequest();
            }

            _context.Entry(consultaBase).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsultaBaseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Consultas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConsultaBase(int id)
        {
            var consultaBase = await _context.Consulta.FindAsync(id);
            if (consultaBase == null)
            {
                return NotFound();
            }

            _context.Consulta.Remove(consultaBase);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConsultaBaseExists(int id)
        {
            return _context.Consulta.Any(e => e.Id == id);
        }
    }
}
