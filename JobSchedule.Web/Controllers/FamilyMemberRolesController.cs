using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobSchedule.Context.Context;
using JobSchedule.Entities.Models;
using JobSchedule.Service.FamilyMemberRoleService;

namespace JobSchedule.Web.Controllers
{
    public class FamilyMemberRolesController : Controller
    {
        private readonly IFamilyMemberRoleSerive _familyMemberRoleService;
   
        public FamilyMemberRolesController( IFamilyMemberRoleSerive familyMemberRoleService)
        {
            _familyMemberRoleService = familyMemberRoleService;
        }

        // GET: FamilyMemberRoles
        public async Task<IActionResult> Index()
        {
            return View(await _familyMemberRoleService.GetAllAsync());
        }

        // GET: FamilyMemberRoles/Details/5
        public async Task<IActionResult> Details(int id)
        {

            var familyMemberRole = await _familyMemberRoleService.GetAsync(id);

            if (familyMemberRole == null)
            {
                return NotFound();
            }

            return View(familyMemberRole);
        }

        // GET: FamilyMemberRoles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FamilyMemberRoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] FamilyMemberRole familyMemberRole)
        {
            if (ModelState.IsValid)
            {
                await _familyMemberRoleService.AddAsync(familyMemberRole);
                return RedirectToAction(nameof(Index));
            }
            return View(familyMemberRole);
        }

        // GET: FamilyMemberRoles/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

            var familyMemberRole = await _familyMemberRoleService.GetAsync(id);
            if (familyMemberRole == null)
            {
                return NotFound();
            }
            return View(familyMemberRole);
        }

        // POST: FamilyMemberRoles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] FamilyMemberRole familyMemberRole)
        {
            if (id != familyMemberRole.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _familyMemberRoleService.UpdateAsync(familyMemberRole);
 
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await _familyMemberRoleService.IsExist(familyMemberRole.Id)==false)
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
            return View(familyMemberRole);
        }

        // GET: FamilyMemberRoles/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
       

            var familyMemberRole = await _familyMemberRoleService.GetAsync(id);
            if (familyMemberRole == null)
            {
                return NotFound();
            }

            return View(familyMemberRole);
        }

        // POST: FamilyMemberRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var familyMemberRole = await _familyMemberRoleService.GetAsync(id);
            await _familyMemberRoleService.RemoveAsync(familyMemberRole);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> FamilyMemberRoleExists(int id)
        {
            return await _familyMemberRoleService.IsExist(id);
        }
    }
}
