using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ijustkeeptryingiguess.Data;
using Ijustkeeptryingiguess.Models;
using Microsoft.AspNetCore.Authorization;

namespace Ijustkeeptryingiguess.Controllers
{
    [Authorize(Roles ="Admin")]
    public class LeadsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LeadsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Denne koden tillater flere koder å kjøre samtidig gjennom async. Her kan flere metoder kjøres samtidig uten å vente i en sekvens
        public async Task<IActionResult> Index()
        {
            // sjekker om databasen saleslead ikke er 0
              return _context.SalesLead != null ? 

                // returnerer visning dersom det er mer enn 0 innhold i databasen
                          View(await _context.SalesLead.ToListAsync()) :

                          // returnerer "Problem" hvis databasen ikke inneholder noe
                          Problem("Entity set 'ApplicationDbContext.SalesLead'  is null.");
        }

        // GET: Returnerer null dersom salesleaden er 0. 
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SalesLead == null)
            {
                return NotFound();
            }
            // returnerer også 0 hvis sales entity ikke er funnet. Returnerer view hvis innholdet i databasen stemmer med tilstanden 
            var salesLeadEntity = await _context.SalesLead
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salesLeadEntity == null)
            {
                return NotFound();
            }

            return View(salesLeadEntity);
        }

        // GET: Leads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Leads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        // Async metode som lager textbokser der brukeren kan taste inn inputs
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Mobile,Email,Source")] SalesLeadEntity salesLeadEntity)
        {

            // hvis inputtet er valid og blir lagret, returnerer den inputet i form av view gjennom return view
            if (ModelState.IsValid)
            {
                _context.Add(salesLeadEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(salesLeadEntity);
        }

        // GET: Leads/Edit/5

        // Edit en int eller ID
        public async Task<IActionResult> Edit(int? id)
        {
            //Hvis det ikke eksisterer ID, returner "not found"
            if (id == null || _context.SalesLead == null)
            {
                return NotFound();
            }
            // Variabelen i salesentity venter på ID
            var salesLeadEntity = await _context.SalesLead.FindAsync(id);
            // Hvis ID er 0 etter ventingen, returner "notfound"
            if (salesLeadEntity == null)
            {
                return NotFound();
            }
            // Ellers returner ID til brukeren gjennom view
            return View(salesLeadEntity);
        }

        // POST: Leads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Mobile,Email,Source")] SalesLeadEntity salesLeadEntity)
        {
            // hvis ingen id = returner 0
            if (id != salesLeadEntity.Id)
            {
                return NotFound();
            }
            // hvis den er valid, oppdater contexten og vent på lagring gjennom "try" 
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salesLeadEntity);
                    await _context.SaveChangesAsync();
                    // ta imot oppdateringen 
                }
                catch (DbUpdateConcurrencyException)
                {
                    // skann igjen etter oppdateringen for å se om det eksisterer en ID. Hvis ikke noe funnet, returner 0
                    if (!SalesLeadEntityExists(salesLeadEntity.Id))
                    {
                        return NotFound();
                    }
                    // ellers returner feilmelding gjennom "throw"
                    else
                    {
                        throw;
                    }

                    // hvis det blir funnet noe etter skanning, returner view til brukeren
                }
                return RedirectToAction(nameof(Index));
            }
            return View(salesLeadEntity);
        }

        // GET: Leads/Delete/5

        // kode for å slette en variabel
        public async Task<IActionResult> Delete(int? id)
        {
            // Hvis ingen ID er funnet i saleslead eller saleslead har ingen innhold, returner 0
            if (id == null || _context.SalesLead == null)
            {
                return NotFound();
            }
            // Sales entity venter på ID oppdatering 
            var salesLeadEntity = await _context.SalesLead
                .FirstOrDefaultAsync(m => m.Id == id);
            // Hvis ID = 0 etter ventingen, returner "ikke funnet"
            if (salesLeadEntity == null)
            {
                return NotFound();
            }
            // Hvis ID stemmer med tilstanden (m => m.Id == id), returner visning
            return View(salesLeadEntity);
        }

        // POST: Leads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        // Funksjon for å slette en variabel
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // Hvis Saleslead er null, returner "problem" 
            if (_context.SalesLead == null)
            {
                return Problem("Entity set 'ApplicationDbContext.SalesLead'  is null.");
            }
            // Saleslead venter på oppdatering av ID. Hvis ID er funnet, sletter den ID-en
            var salesLeadEntity = await _context.SalesLead.FindAsync(id);
            if (salesLeadEntity != null)
            {
                _context.SalesLead.Remove(salesLeadEntity);
            }

            // Lagre endringene etter slett er gjort, og returner brukeren til index siden. 
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        // Hvis det eksisterer Saleslead i form av int eller ID, returner True. Hvis ikke, returner False
        private bool SalesLeadEntityExists(int id)
        {
          return (_context.SalesLead?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
