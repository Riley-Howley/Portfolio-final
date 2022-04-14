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
    public class SoftSkillsController : Controller
    {
        private readonly PortfolioContext _context;

        public SoftSkillsController(PortfolioContext context)
        {
            _context = context;
        }

        // GET: SoftSkills
        public async Task<IActionResult> Index()
        {
            return View(await _context.SoftSkills.ToListAsync());
        }

        // GET: SoftSkills/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var softSkills = await _context.SoftSkills
                .FirstOrDefaultAsync(m => m.SoftSkillsID == id);
            if (softSkills == null)
            {
                return NotFound();
            }

            return View(softSkills);
        }

        // GET: SoftSkills/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SoftSkills/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SoftSkillsID,SoftSkillTitle,SoftSkillpercentage")] SoftSkills softSkills)
        {
            if (ModelState.IsValid)
            {
                _context.Add(softSkills);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(softSkills);
        }

        // GET: SoftSkills/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var softSkills = await _context.SoftSkills.FindAsync(id);
            if (softSkills == null)
            {
                return NotFound();
            }
            return View(softSkills);
        }

        // POST: SoftSkills/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SoftSkillsID,SoftSkillTitle,SoftSkillpercentage")] SoftSkills softSkills)
        {
            if (id != softSkills.SoftSkillsID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(softSkills);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SoftSkillsExists(softSkills.SoftSkillsID))
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
            return View(softSkills);
        }

        // GET: SoftSkills/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var softSkills = await _context.SoftSkills
                .FirstOrDefaultAsync(m => m.SoftSkillsID == id);
            if (softSkills == null)
            {
                return NotFound();
            }

            return View(softSkills);
        }

        // POST: SoftSkills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var softSkills = await _context.SoftSkills.FindAsync(id);
            _context.SoftSkills.Remove(softSkills);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SoftSkillsExists(int id)
        {
            return _context.SoftSkills.Any(e => e.SoftSkillsID == id);
        }
    }
}
