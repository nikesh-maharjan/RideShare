﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RideShareMVC.Models;

namespace RideShareMVC.Controllers
{
    public class TblUsersController : Controller
    {
        private readonly RideShareContext _context;

        public TblUsersController(RideShareContext context)
        {
            _context = context;
        }

        // GET: TblUsers
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblUser.ToListAsync());
        }

        // GET: TblUsers/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            dynamic myModel = new ExpandoObject();
            if (id == null)
            {
                return NotFound();
            }

            myModel.User = await _context.TblUser.FirstOrDefaultAsync(m => m.UserGuid == id);
            //var tblUser = await _context.TblUser
            //    .FirstOrDefaultAsync(m => m.UserGuid == id);
            //var tblAddress = tblUser.Tbladdress;
            

            if (myModel.User == null)
            {
                return NotFound();
            }

            return View(myModel);
        }

        // GET: TblUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserGuid,UserName,EmailAddress,Password,UserCreateDate,UserUpdateDate")] TblUser tblUser)
        {
            if (ModelState.IsValid)
            {
                tblUser.UserGuid = Guid.NewGuid();
                tblUser.UserCreateDate = DateTime.Now;
                tblUser.UserUpdateDate = DateTime.Now;
                _context.Add(tblUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblUser);
        }

        // GET: TblUsers/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblUser = await _context.TblUser.FindAsync(id);
            if (tblUser == null)
            {
                return NotFound();
            }
            return View(tblUser);
        }

        // POST: TblUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("UserGuid,UserName,EmailAddress,Password,UserCreateDate,UserUpdateDate")] TblUser tblUser)
        {
            if (id != tblUser.UserGuid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblUserExists(tblUser.UserGuid))
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
            return View(tblUser);
        }

        // GET: TblUsers/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblUser = await _context.TblUser
                .FirstOrDefaultAsync(m => m.UserGuid == id);
            if (tblUser == null)
            {
                return NotFound();
            }

            return View(tblUser);
        }

        // POST: TblUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tblUser = await _context.TblUser.FindAsync(id);
            _context.TblUser.Remove(tblUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblUserExists(Guid id)
        {
            return _context.TblUser.Any(e => e.UserGuid == id);
        }
    }
}
