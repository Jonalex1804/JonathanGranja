using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JonathanGranja.Data;
using JonathanGranja.Models;

namespace JonathanGranja.Controllers
{
    public class JGranjasController : Controller
    {
        private readonly JonathanGranjaContext _context;

        public JGranjasController(JonathanGranjaContext context)
        {
            _context = context;
        }

        // GET: JGranjas
        public async Task<IActionResult> Index()
        {
            return View(await _context.JGranja.ToListAsync());
        }

        // GET: JGranjas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jGranja = await _context.JGranja
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jGranja == null)
            {
                return NotFound();
            }

            return View(jGranja);
        }

        // GET: JGranjas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JGranjas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Promedio,Nombre,AsisteClases,FechaNacimiento")] JGranja jGranja)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jGranja);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jGranja);
        }

        // GET: JGranjas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jGranja = await _context.JGranja.FindAsync(id);
            if (jGranja == null)
            {
                return NotFound();
            }
            return View(jGranja);
        }

        // POST: JGranjas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Promedio,Nombre,AsisteClases,FechaNacimiento")] JGranja jGranja)
        {
            if (id != jGranja.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jGranja);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JGranjaExists(jGranja.Id))
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
            return View(jGranja);
        }

        // GET: JGranjas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jGranja = await _context.JGranja
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jGranja == null)
            {
                return NotFound();
            }

            return View(jGranja);
        }

        // POST: JGranjas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jGranja = await _context.JGranja.FindAsync(id);
            if (jGranja != null)
            {
                _context.JGranja.Remove(jGranja);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JGranjaExists(int id)
        {
            return _context.JGranja.Any(e => e.Id == id);
        }
    }
}
