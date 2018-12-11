using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobSchedule.Context.Context;
using JobSchedule.Entities.Models;
using JobSchedule.Service.FamilyMemberService;
using JobSchedule.Service.FamilyService;
using JobSchedule.Service.FamilyMemberRoleService;

namespace JobSchedule.Web.Controllers
{
    public class FamilyMembersController : Controller
    {
        private readonly IFamilySerive _familyService;
        private readonly IFamilyMemberRoleSerive _familyMemberRoleService;
        private readonly IFamilyMemberSerive _familyMemberService;


        public FamilyMembersController( IFamilySerive familyService,
                                        IFamilyMemberRoleSerive familyMemberRoleService,
                                        IFamilyMemberSerive familyMemberService)
        {

            _familyMemberService = familyMemberService;
            _familyService = familyService;
            _familyMemberRoleService = familyMemberRoleService;
        }

        // GET: FamilyMembers
        public async Task<IActionResult> Index()
        {
            //var jobDBContext = _context.FamilyMember.Include(f => f.Family).Include(f => f.Role);
            return View(await _familyMemberService.GetAllFamilyWithRoleAsync());
        }

        // GET: FamilyMembers/Details/5
        public async Task<IActionResult> Details(int id)
        {

            //var familyMember = await _context.FamilyMember
            //    .Include(f => f.Family)
            //    .Include(f => f.Role)
            //    .FirstOrDefaultAsync(m => m.Id == id);


            var familyMember = await _familyMemberService.GetAsync(id);

            if (familyMember == null)
            {
                return NotFound();
            }

            return View(familyMember);
        }

        // GET: FamilyMembers/Create
        public async Task<IActionResult> Create()
        {
            var family =  await _familyService.GetAllAsync();
            var familyRole = await _familyMemberRoleService.GetAllAsync();
            ViewData["FamilyId"] = new SelectList(family, "Id", "Name");
            ViewData["RoleId"] = new SelectList(familyRole, "Id", "Name");
            return View();
        }

        // POST: FamilyMembers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,RoleId,FamilyId,TotalPoints")] FamilyMember familyMember)
        {
            if (ModelState.IsValid)
            {
                await  _familyMemberService.AddAsync(familyMember);
                return RedirectToAction(nameof(Index));
            }

            var family = await _familyService.GetAllAsync();
            var familyRole = await _familyMemberRoleService.GetAllAsync();
            ViewData["FamilyId"] = new SelectList(family, "Id", "Name", familyMember.FamilyId);
            ViewData["RoleId"] = new SelectList(familyRole, "Id", "Name", familyMember.RoleId);

            return View(familyMember);
        }

        // GET: FamilyMembers/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

            var familyMember = await _familyMemberService.GetAsync(id);
            if (familyMember == null)
            {
                return NotFound();
            }
            var family = await _familyService.GetAllAsync();
            var familyRole = await _familyMemberRoleService.GetAllAsync();
            ViewData["FamilyId"] = new SelectList(family, "Id", "Name", familyMember.FamilyId);
            ViewData["RoleId"] = new SelectList(familyRole, "Id", "Name", familyMember.RoleId);
            return View(familyMember);
        }

        // POST: FamilyMembers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,RoleId,FamilyId,TotalPoints")] FamilyMember familyMember)
        {
            if (id != familyMember.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _familyMemberService.UpdateAsync(familyMember);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if ( await FamilyMemberExists(familyMember.Id)==false)
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
            var family = await _familyService.GetAllAsync();
            var familyRole = await _familyMemberRoleService.GetAllAsync();
            ViewData["FamilyId"] = new SelectList(family, "Id", "Name", familyMember.FamilyId);
            ViewData["RoleId"] = new SelectList(familyRole, "Id", "Name", familyMember.RoleId);
            return View(familyMember);
        }

        // GET: FamilyMembers/Delete/5
        public async Task<IActionResult> Delete(int id)
        {


            //var familyMember = await _context.FamilyMember
            //    .Include(f => f.Family)
            //    .Include(f => f.Role)
            //    .FirstOrDefaultAsync(m => m.Id == id);


            var familyMember = await _familyMemberService.GetAsync(id);

            if (familyMember == null)
            {
                return NotFound();
            }

            return View(familyMember);
        }

        // POST: FamilyMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var familyMember = await _familyMemberService.GetAsync(id);
            await _familyMemberService.RemoveAsync(familyMember);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> FamilyMemberExists(int id)
        {
            return await _familyMemberService.IsExist(id);
        }
    }
}
