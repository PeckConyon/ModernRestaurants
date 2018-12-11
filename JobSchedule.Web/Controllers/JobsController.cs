using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobSchedule.Context.Context;
using JobSchedule.Entities.Models;
using JobSchedule.Service.JobService;
using JobSchedule.Service.JobTemplateService;
using JobSchedule.Service.JobCategoryService;
using JobSchedule.Service.FamilyMemberService;
using JobSchedule.Service.MemberJobService;
using Microsoft.AspNetCore.Http;

namespace JobSchedule.Web.Controllers
{
    public class JobsController : Controller
    {
      
        private readonly IJobService _jobService;
        private readonly IJobTemplateService _jobTemplateService;
        private readonly IJobCategoryService _jobCategoryService;
        private readonly IFamilyMemberSerive _memberService;
        private readonly IMemberJobService _memberJobService;



        public JobsController(IJobService jobService, 
                              IJobTemplateService jobTemplateService,
                              IJobCategoryService jobCategoryService, 
                              IFamilyMemberSerive memberService,
                              IMemberJobService memberJobService)
        {
            _jobService = jobService;
            _jobTemplateService = jobTemplateService;
            _jobCategoryService = jobCategoryService;
            _memberService = memberService;
            _memberJobService = memberJobService;
        }

        // GET: Jobs
        public async Task<IActionResult> Index()
        {
            return View(await _jobService.GetAllWithCategoryAsync());
        }

        // GET: Jobs/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var job = await _jobService.GetWithCategoryAsync(id);
               
            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

        // GET: Jobs/Create
        public async Task<IActionResult> Create()
        {
            var completedJobs = await _jobTemplateService.GetAllCompletedJobsAsync();

            ViewData["JobTemplateId"] = new SelectList(completedJobs, "Id", "Name");
            ViewData["CategoryId"] = new SelectList(await _jobCategoryService.GetAllAsync(), "Id", "Name");
            return View();
        }

        // POST: Jobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,DateAssigned,DateCompleted,Points,CategoryId")] Job job)
        {
            if (ModelState.IsValid)
            {
                await _jobService.AddAsync(job);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(await _jobCategoryService.GetAllAsync(), "Id", "Name", job.CategoryId);
            return View(job);
        }

        // GET: Jobs/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

            var job = await _jobService.GetAsync(id);

            HttpContext.Session.SetString("JobCompletedDate", job.DateCompleted.ToString());


            if (job == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(await _jobCategoryService.GetAllAsync(), "Id", "Name", job.CategoryId);
            return View(job);
        }

        // POST: Jobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,DateAssigned,DateCompleted,Points,CategoryId")] Job job)
        {
            if (id != job.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //var oldJob = await _jobService.GetAsync(id);
                  var odlDateString =   HttpContext.Session.GetString("JobCompletedDate");

                    await _jobService.UpdateAsync(job);

                    if(odlDateString == "" && job.DateCompleted!=null)
                    {
                        if (job.DateCompleted <= DateTime.Now)
                        {
                            var memberJob = await _memberJobService.GetJobMemberByJobIdAsync(job.Id);

                            if(memberJob!=null)
                            {
                                var member = await _memberService.GetAsync(memberJob.MemberId);

                                member.TotalPoints += job.Points;

                                await _memberService.UpdateAsync(member);
                            }
                         
                        }
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if ( await JobExists(job.Id)==false)
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
            ViewData["CategoryId"] = new SelectList(await _jobCategoryService.GetAllAsync(), "Id", "Name", job.CategoryId);
            return View(job);
        }

        // GET: Jobs/Delete/5
        public async Task<IActionResult> Delete(int id)
        {

            var job = await _jobService.GetWithCategoryAsync(id);
            
            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var job = await _jobService.GetAsync(id);
            await _jobService.RemoveAsync(job);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> JobExists(int id)
        {
            return await _jobService.IsExist(id);
        }
    }
}
