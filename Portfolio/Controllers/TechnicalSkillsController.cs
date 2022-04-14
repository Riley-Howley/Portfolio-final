#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using Portfolio.Models;

namespace Portfolio.Controllers
{
    public class TechnicalSkillsController : Controller
    {
        private readonly PortfolioContext _context;

        public TechnicalSkillsController(PortfolioContext context)
        {
            _context = context;
        }

        // GET: TechnicalSkills
        public async Task<IActionResult> Index()
        {
            return View(await _context.TechnicalSkills.ToListAsync());
        }

        // GET: TechnicalSkills/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var technicalSkills = await _context.TechnicalSkills
                .FirstOrDefaultAsync(m => m.TechnicalSkillsID == id);
            if (technicalSkills == null)
            {
                return NotFound();
            }

            return View(technicalSkills);
        }

        // GET: TechnicalSkills/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TechnicalSkills/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TechnicalSkillsID,TechnicalSkillTitle,TechnicalSkillPercentage")] TechnicalSkills technicalSkills)
        {
            if (ModelState.IsValid)
            {
                _context.Add(technicalSkills);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(technicalSkills);
        }

        // GET: TechnicalSkills/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var technicalSkills = await _context.TechnicalSkills.FindAsync(id);
            if (technicalSkills == null)
            {
                return NotFound();
            }
            return View(technicalSkills);
        }

        // POST: TechnicalSkills/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TechnicalSkillsID,TechnicalSkillTitle,TechnicalSkillPercentage")] TechnicalSkills technicalSkills)
        {
            if (id != technicalSkills.TechnicalSkillsID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(technicalSkills);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TechnicalSkillsExists(technicalSkills.TechnicalSkillsID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(technicalSkills);
        }

        // GET: TechnicalSkills/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var technicalSkills = await _context.TechnicalSkills
                .FirstOrDefaultAsync(m => m.TechnicalSkillsID == id);
            if (technicalSkills == null)
            {
                return NotFound();
            }

            return View(technicalSkills);
        }

        // POST: TechnicalSkills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var technicalSkills = await _context.TechnicalSkills.FindAsync(id);
            _context.TechnicalSkills.Remove(technicalSkills);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TechnicalSkillsExists(int id)
        {
            return _context.TechnicalSkills.Any(e => e.TechnicalSkillsID == id);
        }
    }
}
