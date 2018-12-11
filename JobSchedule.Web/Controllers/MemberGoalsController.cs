using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobSchedule.Context.Context;
using JobSchedule.Entities.Models;
using JobSchedule.Service.MemberGoalService;
using JobSchedule.Service.GoalService;
using JobSchedule.Service.FamilyMemberService;

namespace JobSchedule.Web.Controllers
{
    public class MemberGoalsController : Controller
    {
        private readonly IMemberGoalService _memberGoalService;
        private readonly IGoalSerive _goalService;
        private readonly IFamilyMemberSerive _memberService;

        public MemberGoalsController(IMemberGoalService memberGoalService, IGoalSerive goalService, IFamilyMemberSerive memberService)
        { 
            _memberGoalService = memberGoalService;
            _goalService = goalService;
            _memberService = memberService;
        }

        // GET: MemberGoals
        public async Task<IActionResult> Index()
        {
            return View(await _memberGoalService.GetAllGoalMembersAsync());
        }

        // GET: MemberGoals/Details/5
        public async Task<IActionResult> Details(int id)
        {

            var memberGoal = await _memberGoalService.GetGoalMembersAsync(id);

            if (memberGoal == null)
            {
                return NotFound();
            }

            return View(memberGoal);
        }

        // GET: MemberGoals/Create
        public async Task<IActionResult> Create()
        {
            ViewData["GoalId"] = new SelectList( await _goalService.GetAllAsync(), "Id", "Name");
            ViewData["MemberId"] = new SelectList(await _memberService.GetAllAsync(), "Id", "Name");
            return View();
        }

        // POST: MemberGoals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MemberId,GoalId")] MemberGoal memberGoal)
        {
            if (ModelState.IsValid)
            {
                await _memberGoalService.AddAsync(memberGoal);
                return RedirectToAction(nameof(Index));
            }
            ViewData["GoalId"] = new SelectList(await _goalService.GetAllAsync(), "Id", "Name");
            ViewData["MemberId"] = new SelectList(await _memberService.GetAllAsync(), "Id", "Name");
            return View(memberGoal);
        }

        // GET: MemberGoals/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

            var memberGoal = await _memberGoalService.GetAsync(id);
            if (memberGoal == null)
            {
                return NotFound();
            }
            ViewData["GoalId"] = new SelectList(await _goalService.GetAllAsync(), "Id", "Name");
            ViewData["MemberId"] = new SelectList(await _memberService.GetAllAsync(), "Id", "Name");
            return View(memberGoal);
        }

        // POST: MemberGoals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MemberId,GoalId")] MemberGoal memberGoal)
        {
            if (id != memberGoal.MemberId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _memberGoalService.UpdateAsync(memberGoal);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await MemberGoalExists(memberGoal.MemberId) ==false)
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
            ViewData["GoalId"] = new SelectList(await _goalService.GetAllAsync(), "Id", "Name");
            ViewData["MemberId"] = new SelectList(await _memberService.GetAllAsync(), "Id", "Name");
            return View(memberGoal);
        }

        // GET: MemberGoals/Delete/5
        public async Task<IActionResult> Delete(int id)
        {

            var memberGoal = await _memberGoalService.GetGoalMembersAsync(id);
             
            if (memberGoal == null)
            {
                return NotFound();
            }

            return View(memberGoal);
        }

        // POST: MemberGoals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var memberGoal = await _memberGoalService.GetAsync(id);
            await _memberGoalService.RemoveAsync(memberGoal);
            return RedirectToAction(nameof(Index));
        }

        private Task<bool> MemberGoalExists(int id)
        {
            return _memberGoalService.IsExist(id);
        }


        [HttpGet]
        public async Task<JsonResult> GetFamily(int memberId)
        {
            var family = await _memberService.GetFamilyByMemberId(memberId);
            return Json(family);
        }
    }
}
