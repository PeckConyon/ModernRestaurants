using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobSchedule.Entities.Models;
using JobSchedule.Service.GoalService;
using JobSchedule.Service.AwardService;
using Microsoft.AspNetCore.Http;
using JobSchedule.Service.MemberJobService;
using JobSchedule.Service.FamilyMemberService;
using JobSchedule.Service.MemberGoalService;

namespace JobSchedule.Web.Controllers
{
    public class GoalsController : Controller
    {
        private readonly IGoalSerive _goalService;
        private readonly IAwardService _awardService;
        private readonly IMemberJobService _memberJobService;
        private readonly IMemberGoalService _memberGoalService;
        private readonly IFamilyMemberSerive _memberService;

        public GoalsController(IGoalSerive goalService,
                               IAwardService awardService,
                               IMemberJobService memberJobService,
                               IFamilyMemberSerive memberService,
                               IMemberGoalService memberGoalService)
        {
            _goalService = goalService;
            _awardService = awardService;
            _memberJobService = memberJobService;
            _memberService = memberService;
            _memberGoalService = memberGoalService;
        }

        // GET: Goals
        public async Task<IActionResult> Index()
        {
              return View(await _goalService.GetAllWithAwardsAsync());
        }

        // GET: Goals/Details/5
        public async Task<IActionResult> Details(int id)
        {

            var goals = await _goalService.GetAllWithAwardsAsync();

            if (goals == null)
            {
                return NotFound();
            }

            return View(goals);
        }

        // GET: Goals/Create
        public async Task<IActionResult> Create()
        {
            // ViewData["AwardId"] = new SelectList(_context.Award, "Id", "Name");
            ViewData["AwardId"] = new SelectList( await _awardService.GetAllAsync(), "Id", "Name");
            return View();
        }

        // POST: Goals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,AwardId,DateCreated,DateAwarded")] Goals goals)
        {
            if (ModelState.IsValid)
            {
                await _goalService.AddAsync(goals);
                return RedirectToAction(nameof(Index));
            }
            ViewData["AwardId"] = new SelectList(await _awardService.GetAllAsync(), "Id", "Name", goals.AwardId);
            return View(goals);
        }

        // GET: Goals/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
 
            var goals = await _goalService.GetWithAwardAsync(id);

            HttpContext.Session.SetString("GaolAwardedDate", goals.DateAwarded.ToString());

            if (goals == null)
            {
                return NotFound();
            }
            // ViewData["AwardId"] = new SelectList(_context.Award, "Id", "Name", goals.AwardId);
            ViewData["AwardId"] = new SelectList(await _awardService.GetAllAsync(), "Id", "Name", goals.AwardId);
            return View(goals);
        }

        // POST: Goals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,AwardId,DateCreated,DateAwarded")] Goals goals)
        {
            if (id != goals.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var odlDateString = HttpContext.Session.GetString("GaolAwardedDate");

                    await _goalService.UpdateAsync(goals);

                    if (odlDateString == "" && goals.DateAwarded != null)
                    {
                        if (goals.DateAwarded <= DateTime.Now)
                        {
                            var memberGoal = await _memberGoalService.GetGoalMemberByGoalIdAsync(goals.Id);
                            if(memberGoal!=null)
                            {
                                var member = await _memberService.GetAsync(memberGoal.MemberId);

                                var goalWithAward =  await _goalService.GetWithAwardAsync(goals.Id);

                                member.TotalPoints += goalWithAward.Award.Points;

                                await _memberService.UpdateAsync(member);
                            }
                           
                        }
                    }
                  
                }
                catch (DbUpdateConcurrencyException)
                {
                    if ( await _goalService.IsExist(goals.Id)==false)
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
            ViewData["AwardId"] = new SelectList(await _awardService.GetAllAsync(), "Id", "Name", goals.AwardId);
            return View(goals);
        }

        // GET: Goals/Delete/5
        public async Task<IActionResult> Delete(int id)
        {


            //var goals = await _context.Goals
            //    .Include(g => g.Award)
            //    .FirstOrDefaultAsync(m => m.Id == id);


            var goals = await _goalService.GetWithAwardAsync(id);
            if (goals == null)
            {
                return NotFound();
            }

            return View(goals);
        }

        // POST: Goals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var goals = await _goalService.GetAsync(id);
            await  _goalService.RemoveAsync(goals);
   
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> GoalsExists(int id)
        {
            return await _goalService.IsExist(id);
        }
    }
}
