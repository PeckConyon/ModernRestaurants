using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobSchedule.Context.Context;
using JobSchedule.Entities.Models;
using JobSchedule.Service.JobTemplateService;
using JobSchedule.Service.JobCategoryService;

namespace JobSchedule.Web.Controllers
{
    public class JobTemplatesController : Controller
    {

        private readonly IJobTemplateService _jobTemplateService;
        private readonly IJobCategoryService _jobCategoryService;

        public JobTemplatesController(IJobTemplateService jobTemplateService, IJobCategoryService jobCategoryService)
        {
            _jobTemplateService = jobTemplateService;
            _jobCategoryService = jobCategoryService;
        }

        // GET: JobTemplates
        public async Task<IActionResult> Index()
        {
            return View(await _jobTemplateService.GetAllWithCategoryAsync());
        }

        // GET: JobTemplates/Details/5
        public async Task<IActionResult> Details(int id)
        {

            var jobTemplate = await _jobTemplateService.GetWithCategoryAsync(id);

            if (jobTemplate == null)
            {
                return NotFound();
            }

            return View(jobTemplate);
        }

        // GET: JobTemplates/Create
        public async Task<IActionResult> Create()
        {
            ViewData["CategoryId"] = new SelectList( await _jobCategoryService.GetAllAsync(), "Id", "Name");
            return View();
        }

        // POST: JobTemplates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,DateAssigned,DateCompleted,Points,CategoryId")] JobTemplate jobTemplate)
        {
            if (ModelState.IsValid)
            {
                await _jobTemplateService.AddAsync(jobTemplate);
                return RedirectToAction(nameof(Index));
            }

            ViewData["CategoryId"] = new SelectList(await _jobCategoryService.GetAllAsync(), "Id", "Name", jobTemplate.CategoryId);
            return View(jobTemplate);
        }

        // GET: JobTemplates/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

            var jobTemplate = await _jobTemplateService.GetAsync(id);
            if (jobTemplate == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(await _jobCategoryService.GetAllAsync(), "Id", "Name", jobTemplate.CategoryId);
            return View(jobTemplate);
        }

        // POST: JobTemplates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,DateAssigned,DateCompleted,Points,CategoryId")] JobTemplate jobTemplate)
        {
            if (id != jobTemplate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _jobTemplateService.UpdateAsync(jobTemplate);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await JobTemplateExists(jobTemplate.Id))
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
            ViewData["CategoryId"] = new SelectList(await _jobCategoryService.GetAllAsync(), "Id", "Name", jobTemplate.CategoryId);
            return View(jobTemplate);
        }

        // GET: JobTemplates/Delete/5
        public async Task<IActionResult> Delete(int id)
        {

            var jobTemplate = await _jobTemplateService.GetWithCategoryAsync(id);

            if (jobTemplate == null)
            {
                return NotFound();
            }

            return View(jobTemplate);
        }

        // POST: JobTemplates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jobTemplate = await _jobTemplateService.GetAsync(id);
           await _jobTemplateService.RemoveAsync(jobTemplate);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> JobTemplateExists(int id)
        {
            return await _jobTemplateService.IsExist(id);
        }

        [HttpGet]
        public async  Task<JsonResult> GetTemplate(int jobTemplateId)
        {
            var template = await _jobTemplateService.GetAsync(jobTemplateId);
            return Json(template);
        }
    }
}
