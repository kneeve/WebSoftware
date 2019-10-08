/**
 * Author:    Kaelin Hoang
 * Partner:   None
 * Date:      9/13/2019
 * Course:    CS 4540, University of Utah, School of Computing
 * Copyright: CS 4540 and Kaelin Hoang - This work may not be copied for use in Academic Coursework.
 *
 * I, Kaelin Hoang, certify that I wrote this code from scratch and did not copy it in part or whole from 
 * another source.  Any references used in the completion of the assignment are cited in my README file.
 *
 * File Contents
 *
 *    Controls the views for the learning outcomes views
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EFGetStarted.AspNetCore.NewDb.Models;
using Microsoft.AspNetCore.Authorization;
using System.Collections;

namespace WebApplication1.Controllers
{
    [Authorize(Roles = "Admin, Instructor")]
    public class LearningOutcomesController : Controller
    {
        private readonly CourseContext _context;

        public LearningOutcomesController(CourseContext context)
        {
            _context = context;
        }

        // GET: LearningOutcomes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Descriptions.ToListAsync());
        }

        // GET: LearningOutcomes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var learningOutcomes = await _context.Descriptions
                .FirstOrDefaultAsync(m => m.LearningOutcomesID == id);
            if (learningOutcomes == null)
            {
                return NotFound();
            }

            return View(learningOutcomes);
        }

        // GET: LearningOutcomes/Create
        public IActionResult Create()
        {
            IEnumerable items = _context.Courses.Select(c => new SelectListItem()
            {
                Text = c.Description, Value = "" + c.CourseInstanceID
            }).ToList(); ViewData["Courses"] = items; return View();
        }

        // POST: LearningOutcomes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LearningOutcomesID,Name,Description,CourseInstanceID")] LearningOutcomes learningOutcomes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(learningOutcomes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(learningOutcomes);
        }

        // GET: LearningOutcomes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var learningOutcomes = await _context.Descriptions.FindAsync(id);
            if (learningOutcomes == null)
            {
                return NotFound();
            }
            return View(learningOutcomes);
        }

        // POST: LearningOutcomes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LearningOutcomesID,Name,Description,CourseInstanceID")] LearningOutcomes learningOutcomes)
        {
            if (id != learningOutcomes.LearningOutcomesID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(learningOutcomes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LearningOutcomesExists(learningOutcomes.LearningOutcomesID))
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
            return View(learningOutcomes);
        }

        // GET: LearningOutcomes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var learningOutcomes = await _context.Descriptions
                .FirstOrDefaultAsync(m => m.LearningOutcomesID == id);
            if (learningOutcomes == null)
            {
                return NotFound();
            }

            return View(learningOutcomes);
        }

        // POST: LearningOutcomes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var learningOutcomes = await _context.Descriptions.FindAsync(id);
            _context.Descriptions.Remove(learningOutcomes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LearningOutcomesExists(int id)
        {
            return _context.Descriptions.Any(e => e.LearningOutcomesID == id);
        }
    }
}
