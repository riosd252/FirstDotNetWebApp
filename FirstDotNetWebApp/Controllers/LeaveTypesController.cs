using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FirstDotNetWebApp.Data;
using FirstDotNetWebApp.Models;

namespace FirstDotNetWebApp.Controllers
{
    public class LeaveTypesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public LeaveTypesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: LeaveAllocations
        public async Task<IActionResult> Index()
        {
            var leaveTypesVm = _mapper.Map<List<LeaveTypeVM>>(await _context.LeaveTypes.ToListAsync());
            return View(leaveTypesVm);
        }

        // GET: LeaveAllocations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveTypeVm = _mapper.Map<LeaveTypeVM>(await _context.LeaveTypes.FirstOrDefaultAsync(m => m.Id == id));
            if (leaveTypeVm == null)
            {
                return NotFound();
            }

            return View(leaveTypeVm);
        }

        // GET: LeaveAllocations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LeaveAllocations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LeaveTypeVM leaveTypeVm)
        {
            if (ModelState.IsValid)
            {
                var leaveType = _mapper.Map<LeaveType>(leaveTypeVm);
                _context.Add(leaveType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            return View(leaveTypeVm);
        }

        // GET: LeaveAllocations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveTypeVm = _mapper.Map<LeaveTypeVM>(await _context.LeaveTypes.FindAsync(id));
            if (leaveTypeVm == null)
            {
                return NotFound();
            }
            
            return View(leaveTypeVm);
        }

        // POST: LeaveAllocations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, LeaveTypeVM leaveTypeVm)
        {
            if (id != leaveTypeVm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var leaveType = _mapper.Map<LeaveType>(leaveTypeVm);
                    _context.Update(leaveType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeaveTypeExists(leaveTypeVm.Id))
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
            
            return View(leaveTypeVm);
        }

        // GET: LeaveAllocations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveType = await _context.LeaveTypes.FirstOrDefaultAsync(m => m.Id == id);
            if (leaveType == null)
            {
                return NotFound();
            }

            return View(leaveType);
        }

        // POST: LeaveAllocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var leaveType = await _context.LeaveTypes.FindAsync(id);
            if (leaveType != null)
            {
                _context.LeaveTypes.Remove(leaveType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeaveTypeExists(int id)
        {
          return (_context.LeaveTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}