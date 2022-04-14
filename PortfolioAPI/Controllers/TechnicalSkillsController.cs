#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Models;
using PortfolioAPI.Data;

namespace PortfolioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnicalSkillsController : ControllerBase
    {
        private readonly PortfolioAPIContext _context;

        public TechnicalSkillsController(PortfolioAPIContext context)
        {
            _context = context;
        }

        // GET: api/TechnicalSkills
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TechnicalSkills>>> GetTechnicalSkills()
        {
            return await _context.TechnicalSkills.ToListAsync();
        }

        // GET: api/TechnicalSkills/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TechnicalSkills>> GetTechnicalSkills(int id)
        {
            var technicalSkills = await _context.TechnicalSkills.FindAsync(id);

            if (technicalSkills == null)
            {
                return NotFound();
            }

            return technicalSkills;
        }

        // PUT: api/TechnicalSkills/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTechnicalSkills(int id, TechnicalSkills technicalSkills)
        {
            if (id != technicalSkills.TechnicalSkillsID)
            {
                return BadRequest();
            }

            _context.Entry(technicalSkills).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TechnicalSkillsExists(id))
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

        // POST: api/TechnicalSkills
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TechnicalSkills>> PostTechnicalSkills(TechnicalSkills technicalSkills)
        {
            _context.TechnicalSkills.Add(technicalSkills);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTechnicalSkills", new { id = technicalSkills.TechnicalSkillsID }, technicalSkills);
        }

        // DELETE: api/TechnicalSkills/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTechnicalSkills(int id)
        {
            var technicalSkills = await _context.TechnicalSkills.FindAsync(id);
            if (technicalSkills == null)
            {
                return NotFound();
            }

            _context.TechnicalSkills.Remove(technicalSkills);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TechnicalSkillsExists(int id)
        {
            return _context.TechnicalSkills.Any(e => e.TechnicalSkillsID == id);
        }
    }
}
