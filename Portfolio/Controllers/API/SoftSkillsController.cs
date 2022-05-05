#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Models;
using Portfolio.Data;

namespace PortfolioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoftSkillsController : ControllerBase
    {
        private readonly PortfolioContext _context;

        public SoftSkillsController(PortfolioContext context)
        {
            _context = context;
        }

        // GET: api/SoftSkills
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SoftSkills>>> GetSoftSkills()
        {
            return await _context.SoftSkills.ToListAsync();
        }

        // GET: api/SoftSkills/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SoftSkills>> GetSoftSkills(int id)
        {
            var softSkills = await _context.SoftSkills.FindAsync(id);

            if (softSkills == null)
            {
                return NotFound();
            }

            return softSkills;
        }

        // PUT: api/SoftSkills/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSoftSkills(int id, SoftSkills softSkills)
        {
            if (id != softSkills.SoftSkillsID)
            {
                return BadRequest();
            }

            _context.Entry(softSkills).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SoftSkillsExists(id))
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

        // POST: api/SoftSkills
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SoftSkills>> PostSoftSkills(SoftSkills softSkills)
        {
            _context.SoftSkills.Add(softSkills);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSoftSkills", new { id = softSkills.SoftSkillsID }, softSkills);
        }

        // DELETE: api/SoftSkills/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSoftSkills(int id)
        {
            var softSkills = await _context.SoftSkills.FindAsync(id);
            if (softSkills == null)
            {
                return NotFound();
            }

            _context.SoftSkills.Remove(softSkills);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SoftSkillsExists(int id)
        {
            return _context.SoftSkills.Any(e => e.SoftSkillsID == id);
        }
    }
}
