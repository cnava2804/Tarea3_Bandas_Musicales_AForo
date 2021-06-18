using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tarea3_Bandas_Musicales.Data;
using Tarea3_Bandas_Musicales.Models;

namespace Tarea3_Bandas_Musicales.Controllers
{
    public class Bandas_Musicales_Controller : Controller
    {
        private readonly ApplicationDbContext db;

        public Bandas_Musicales_Controller(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<IActionResult> Index()
        {
            return View(await db.bandas_Musicales.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bandM = await db.bandas_Musicales.FirstOrDefaultAsync(b => b.BandaM_Id == id);

            if (bandM == null)
            {
                return NotFound();
            }

            return View(bandM);


        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Bandas_Musicales bandas_Musicales)
        {
            if (ModelState.IsValid)
            {
                db.Add(bandas_Musicales);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bandas_Musicales);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bandM = await db.bandas_Musicales.FindAsync(id);

            if (bandM == null)
            {
                return NotFound();
            }

            return View(bandM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Bandas_Musicales bandM)
        {
            if (id != bandM.BandaM_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(bandM);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }

                return RedirectToAction(nameof(Index));
            }

            return View(bandM);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bandM = await db.bandas_Musicales.FirstOrDefaultAsync(b => b.BandaM_Id == id);

            if (bandM == null)
            {
                return NotFound();
            }

            return View(bandM);

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var bandM = await db.bandas_Musicales.FindAsync(id);
            db.bandas_Musicales.Remove(bandM);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
