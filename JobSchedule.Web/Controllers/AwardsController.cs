using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobSchedule.Context.Context;
using JobSchedule.Entities.Models;
using JobSchedule.Context.UnitOfWork;
using JobSchedule.Service.AwardService;

namespace JobSchedule.Web.Controllers
{
    public class AwardsController : Controller
    {

        private readonly IAwardService _awardService;

        public AwardsController(IAwardService awardService) // DI
        {
            _awardService = awardService;
        }


        // GET: Awards
        public async Task<IActionResult> Index()
        {
              return View(await _awardService.GetAllAsync());
        }

        // GET: Awards/Details/5
        public async Task<IActionResult> Details(int id)
        {
          
            var award = await _awardService.GetAsync(id);
            if (award == null)
            {
                return NotFound();
            }

            return View(award);
        }

        // GET: Awards/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Awards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Points")] Award award)
        {
            if (ModelState.IsValid)
            {
                await _awardService.AddAsync(award);
                return RedirectToAction(nameof(Index));
            }
            return View(award);
        }

        // GET: Awards/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
           
            var award = await _awardService.GetAsync(id);
            if (award == null)
            {
                return NotFound();
            }
            return View(award);
        }

        // POST: Awards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Points")] Award award)
        {
            if (id != award.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _awardService.UpdateAsync(award);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await _awardService.IsExist(award.Id)==false)
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
            return View(award);
        }

        // GET: Awards/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
     
            var award = await _awardService.GetAsync(id);
 
            if (award == null)
            {
                return NotFound();
            }

            return View(award);
        }

        // POST: Awards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var award = await _awardService.GetAsync(id);
            await _awardService.RemoveAsync(award);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> AwardExistsAsync(int id)
        {
            return await _awardService.IsExist(id);
        }
    }
}
