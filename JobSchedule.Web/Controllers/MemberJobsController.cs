using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobSchedule.Entities.Models;
using JobSchedule.Service.JobService;
using JobSchedule.Service.FamilyMemberService;
using JobSchedule.Service.MemberJobService;

namespace JobSchedule.Web.Controllers
{
    public class MemberJobsController : Controller
    {

        private readonly IMemberJobService _memberJobService;
        private readonly IJobService _jobService;
        private readonly IFamilyMemberSerive _memberService;

        public MemberJobsController(IJobService jobService, IFamilyMemberSerive memberService, IMemberJobService memberJobService)
        {
            _memberService = memberService;
            _memberJobService = memberJobService;
            _jobService = jobService;
        }

        // GET: MemberJobs
        public async Task<IActionResult> Index()
        {
            //var jobDBContext = _context.MemberJob.Include(m => m.Job).Include(m => m.Member);
            return View(await _memberJobService.GetAllJobMembersAsync());
        }

        // GET: MemberJobs/Details/5
        public async Task<IActionResult> Details(int id)
        {

            var memberJob = await _memberJobService.GetJobMembersAsync(id);

            if (memberJob == null)
            {
                return NotFound();
            }

            return View(memberJob);
        }

        // GET: MemberJobs/Create
        public async Task<IActionResult> Create()
        {
            ViewData["JobId"] = new SelectList( await _jobService.GetAllPendingJobsAsync(), "Id", "Name");
            ViewData["MemberId"] = new SelectList( await _memberService.GetAllAsync(), "Id", "Name");
            return View();
        }

        // POST: MemberJobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MemberId,JobId")] MemberJob memberJob)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _memberJobService.AddAsync(memberJob);

                    var job = await _jobService.GetAsync(memberJob.JobId);
                    job.DateAssigned = DateTime.Now;

                    await _jobService.UpdateAsync(job);

                    return RedirectToAction(nameof(Index));
                }

                ViewData["JobId"] = new SelectList(await _jobService.GetAllPendingJobsAsync(), "Id", "Name", memberJob.JobId);
                ViewData["MemberId"] = new SelectList(await _memberService.GetAllAsync(), "Id", "Name", memberJob.MemberId);
                return View(memberJob);
            }
            catch (Exception ex)
            {

                throw;
            }
        
        }

        // GET: MemberJobs/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
 
            var memberJob = await _memberJobService.GetJobMembersAsync(id);
            if (memberJob == null)
            {
                return NotFound();
            }

            ViewData["JobId"] = new SelectList(await _jobService.GetAllPendingJobsAsync(), "Id", "Name", memberJob.JobId);
            ViewData["MemberId"] = new SelectList(await _memberService.GetAllAsync(), "Id", "Name", memberJob.MemberId);
            return View(memberJob);
        }

        // POST: MemberJobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MemberId,JobId")] MemberJob memberJob)
        {
            if (id != memberJob.MemberId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   await _memberJobService.UpdateAsync(memberJob);
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if ( await MemberJobExists(memberJob.MemberId)  ==false)
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

            ViewData["JobId"] = new SelectList(await _jobService.GetAllPendingJobsAsync(), "Id", "Name", memberJob.JobId);
            ViewData["MemberId"] = new SelectList(await _memberService.GetAllAsync(), "Id", "Name", memberJob.MemberId);
            return View(memberJob);
        }

        // GET: MemberJobs/Delete/5
        public async Task<IActionResult> Delete(int id)
        {

            //var memberJob = await _context.MemberJob
            //    .Include(m => m.Job)
            //    .Include(m => m.Member)
            //    .FirstOrDefaultAsync(m => m.MemberId == id);

            var memberJob = await _memberJobService.GetJobMembersAsync(id);

            if (memberJob == null)
            {
                return NotFound();
            }

            return View(memberJob);
        }

        // POST: MemberJobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var memberJob = await _memberJobService.GetJobMembersAsync(id);
            await  _memberJobService.RemoveAsync(memberJob);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> MemberJobExists(int id)
        {
            return await _memberJobService.IsExist(id);
        }

        [HttpGet]
        public async Task<JsonResult> GetFamily(int memberId)
        {
            var family = await _memberService.GetFamilyByMemberId(memberId);
            return Json(family);
        }
    }
}
