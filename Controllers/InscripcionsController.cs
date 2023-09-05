using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CrudUniversity.Data;
using CrudUniversity.Models;

namespace CrudUniversity.Controllers
{
    public class InscripcionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InscripcionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Inscripcions
        public async Task<IActionResult> Index(string searchString)
        {
            var query = _context.Inscripcion.Include(e => e.cursos).Include(e => e.estudiante);

            if (!String.IsNullOrEmpty(searchString))
            {
                var searchStringLower = searchString.ToLower(); // Convertir la búsqueda a minúsculas

                // Obtener todas las inscripciones de la base de datos y luego filtrar en memoria
                var inscripciones = await query.ToListAsync();

                inscripciones = inscripciones.Where(i =>
                    i.grado != null && i.grado.ToString().ToLower().Contains(searchStringLower)
                ).ToList();

                return View(inscripciones);
            }

            return View(await query.ToListAsync());
        }



        // GET: Inscripcions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Inscripcion == null)
            {
                return NotFound();
            }

            var inscripcion = await _context.Inscripcion
                .Include(e => e.cursos)
                .Include(e => e.estudiante)
                .FirstOrDefaultAsync(m => m.IdInscripcion == id);
            if (inscripcion == null)
            {
                return NotFound();
            }

            return View(inscripcion);
        }

        // GET: Inscripcions/Create
        public IActionResult Create()
        {
            ViewData["IdCurso"] = new SelectList(_context.Cursos, "IdCurso", "Titulo");
            ViewData["IdEstudiante"] = new SelectList(_context.Estudiante, "IdEstudiante", "Nombre");
            ViewData["Grado"] = new SelectList(Enum.GetValues(typeof(grado)).Cast<grado>().ToList());
            return View();
        }

        // POST: Inscripcions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> Create([Bind("IdInscripcion,IdCurso,IdEstudiante,grado")] Inscripcion enrollment)
        {
            if (ModelState.IsValid)
            {
                
                enrollment.cursos = _context.Cursos.Find(enrollment.IdCurso);
                enrollment.estudiante = _context.Estudiante.Find(enrollment.IdEstudiante);

                _context.Add(enrollment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCurso"] = new SelectList(_context.Cursos, "IdCurso", "Titulo", enrollment.IdCurso);
            ViewData["IdEstudiante"] = new SelectList(_context.Estudiante, "IdEstudiante", "Nombre", enrollment.IdEstudiante);
            ViewData["Grado"] = new SelectList(Enum.GetValues(typeof(grado)).Cast<grado>().ToList());
            return View(enrollment);
        }


        // GET: Inscripcions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Inscripcion == null)
            {
                return NotFound();
            }

            var inscripcion = await _context.Inscripcion.FindAsync(id);
            if (inscripcion == null)
            {
                return NotFound();
            }
            ViewData["IdCurso"] = new SelectList(_context.Cursos, "IdCurso", "Titulo", inscripcion.IdCurso);
            ViewData["IdEstudiante"] = new SelectList(_context.Estudiante, "IdEstudiante", "Nombre", inscripcion.IdEstudiante);
            ViewData["Grado"] = new SelectList(Enum.GetValues(typeof(grado)).Cast<grado>().ToList());
            return View(inscripcion);
        }

        // POST: Inscripcions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdInscripcion,IdCurso,IdEstudiante,grado")] Inscripcion inscripcion)
        {
            if (id != inscripcion.IdInscripcion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inscripcion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InscripcionExists(inscripcion.IdInscripcion))
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
            ViewData["IdCurso"] = new SelectList(_context.Cursos, "IdCurso", "Titulo", inscripcion.IdCurso);
            ViewData["IdEstudiante"] = new SelectList(_context.Estudiante, "IdEstudiante", "Nombre", inscripcion.IdEstudiante);
            ViewData["Grado"] = new SelectList(Enum.GetValues(typeof(grado)).Cast<grado>().ToList());
            return View(inscripcion);
        }

        // GET: Inscripcions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Inscripcion == null)
            {
                return NotFound();
            }

            var inscripcion = await _context.Inscripcion
                .Include(i => i.estudiante)  
                 .Include(i => i.cursos)
                .FirstOrDefaultAsync(m => m.IdInscripcion == id);

            if (inscripcion == null)
            {
                return NotFound();
            }

            return View(inscripcion);
        }

        // POST: Inscripcions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Inscripcion == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Inscripcion'  is null.");
            }
            var inscripcion = await _context.Inscripcion.FindAsync(id);
            if (inscripcion != null)
            {
                _context.Inscripcion.Remove(inscripcion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InscripcionExists(int id)
        {
          return (_context.Inscripcion?.Any(e => e.IdInscripcion == id)).GetValueOrDefault();
        }
    }
}
