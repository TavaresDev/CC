using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CannabisChoice.Models;

namespace CannabisChoice.Controllers
{
    public class StrainInfoController : Controller
    {
        private readonly CCContext _context;

        public StrainInfoController(CCContext context)
        {
            _context = context;
        }

        // GET: StrainInfo
        public async Task<IActionResult> Index()
        {
            return View(await _context.StrainInfo.ToListAsync());
        }

        // GET: StrainInfo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var strainInfo = await _context.StrainInfo
                .FirstOrDefaultAsync(m => m.StrainId == id);
            if (strainInfo == null)
            {
                return NotFound();
            }

            return View(strainInfo);
        }

        // GET: StrainInfo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StrainInfo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StrainId,Sname,Thc,Cbd,Terpenes,Pic,Effects")] StrainInfo strainInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(strainInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(strainInfo);
        }

        // GET: StrainInfo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var strainInfo = await _context.StrainInfo.FindAsync(id);
            if (strainInfo == null)
            {
                return NotFound();
            }
            return View(strainInfo);
        }

        // POST: StrainInfo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StrainId,Sname,Thc,Cbd,Terpenes,Pic,Effects")] StrainInfo strainInfo)
        {
            if (id != strainInfo.StrainId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(strainInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StrainInfoExists(strainInfo.StrainId))
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
            return View(strainInfo);
        }

        // GET: StrainInfo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var strainInfo = await _context.StrainInfo
                .FirstOrDefaultAsync(m => m.StrainId == id);
            if (strainInfo == null)
            {
                return NotFound();
            }

            return View(strainInfo);
        }

        // POST: StrainInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var strainInfo = await _context.StrainInfo.FindAsync(id);
            _context.StrainInfo.Remove(strainInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StrainInfoExists(int id)
        {
            return _context.StrainInfo.Any(e => e.StrainId == id);
        }
    }
}
