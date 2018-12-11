using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobSchedule.Context.Context;
using JobSchedule.Entities.Models;
using JobSchedule.Service.FamilyService;

namespace JobSchedule.Web.Controllers
{
    public class FamiliesController : Controller
    {
        private readonly IFamilySerive _familyService;

        public FamiliesController(IFamilySerive familyService)
        {
            _familyService = familyService;
        }

        // GET: Families
        public async Task<IActionResult> Index()
        {
            return View(await _familyService.GetAllAsync());
        }

        // GET: Families/Details/5
        public async Task<IActionResult> Details(int id)
        {

            var family = await _familyService.GetAsync(id);

            if (family == null)
            {
                return NotFound();
            }

            return View(family);
        }

        // GET: Families/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Families/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Family family)
        {
            if (ModelState.IsValid)
            {
               await _familyService.AddAsync(family);
             
                return RedirectToAction(nameof(Index));
            }
            return View(family);
        }

        // GET: Families/Edit/5
        public async Task<IActionResult> Edit(int id)
        {


            var family = await _familyService.GetAsync(id);
            if (family == null)
            {
                return NotFound();
            }
            return View(family);
        }

        // POST: Families/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Family family)
        {
            if (id != family.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _familyService.UpdateAsync(family); 
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await _familyService.IsExist(family.Id)==false)
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
            return View(family);
        }

        // GET: Families/Delete/5
        public async Task<IActionResult> Delete(int id)
        {

            var family = await _familyService.GetAsync(id);
            if (family == null)
            {
                return NotFound();
            }

            return View(family);
        }

        // POST: Families/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var family = await _familyService.GetAsync(id);
            await _familyService.RemoveAsync(family);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> FamilyExists(int id)
        {
            return await _familyService.IsExist(id);
        }
    }
}
