using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobSchedule.Context.Context;
using JobSchedule.Entities.Models;
using JobSchedule.Service.JobCategoryService;

namespace JobSchedule.Web.Controllers
{
    public class JobCategoriesController : Controller
    {

        private readonly IJobCategoryService _jobCategoryService;

        public JobCategoriesController(IJobCategoryService jobCategoryServicet)
        {
            _jobCategoryService = jobCategoryServicet;
        }

        // GET: JobCategories
        public async Task<IActionResult> Index()
        {
            return View(await _jobCategoryService.GetAllAsync());
        }

        // GET: JobCategories/Details/5
        public async Task<IActionResult> Details(int id)
        {

            var jobCategory = await _jobCategoryService.GetAsync(id);
             
            if (jobCategory == null)
            {
                return NotFound();
            }

            return View(jobCategory);
        }

        // GET: JobCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JobCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Desscription")] JobCategory jobCategory)
        {
            if (ModelState.IsValid)
            {
                await _jobCategoryService.AddAsync(jobCategory);
             
                return RedirectToAction(nameof(Index));
            }
            return View(jobCategory);
        }

        // GET: JobCategories/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
          

            var jobCategory = await _jobCategoryService.GetAsync(id);
            if (jobCategory == null)
            {
                return NotFound();
            }
            return View(jobCategory);
        }

        // POST: JobCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Desscription")] JobCategory jobCategory)
        {
            if (id != jobCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _jobCategoryService.UpdateAsync(jobCategory);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if ( await JobCategoryExists(id)==false)
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
            return View(jobCategory);
        }

        // GET: JobCategories/Delete/5
        public async Task<IActionResult> Delete(int id)
        {

            var jobCategory = await _jobCategoryService.GetAsync(id);
            
            if (jobCategory == null)
            {
                return NotFound();
            }

            return View(jobCategory);
        }

        // POST: JobCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jobCategory = await _jobCategoryService.GetAsync(id);
            await _jobCategoryService.RemoveAsync(jobCategory);
           
            return RedirectToAction(nameof(Index));
        }

        private Task<bool> JobCategoryExists(int id)
        {
            return _jobCategoryService.IsExist(id);
        }
    }
}
