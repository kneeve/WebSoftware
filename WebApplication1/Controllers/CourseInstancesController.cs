/**
 * Author:    Kaelin Hoang
 * Partner:   None
 * Date:      9/27/2019
 * Course:    CS 4540, University of Utah, School of Computing
 * Copyright: CS 4540 and Kaelin Hoang - This work may not be copied for use in Academic Coursework.
 *
 * I, Kaelin Hoang, certify that I wrote this code from scratch and did not copy it in part or whole from 
 * another source.  Any references used in the completion of the assignment are cited in my README file.
 *
 * File Contents
 *
 *    Controls the views for the course instances views
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
/// <summary>
/// Auto generated controller
/// </summary>
namespace WebApplication1.Controllers
{
    [Authorize(Roles = "Instructor, Chair")]
    public class CourseInstancesController : Controller
    {
        private readonly CourseContext _context;

        public CourseInstancesController(CourseContext context)
        {
            _context = context;
        }

        // GET: CourseInstances
        [Authorize(Roles ="Chair")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Courses.ToListAsync());
        }

        // GET: CourseInstances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseInstance = await _context.Courses
                .FirstOrDefaultAsync(m => m.CourseInstanceID == id);
            var note = await _context.CourseNotes
                .FirstOrDefaultAsync(m => m.CourseInstanceID == id);

            courseInstance.Note = note;
            if (courseInstance == null)
            {
                return NotFound();
            }

            return View(courseInstance);
        }

        // GET: CourseInstances/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CourseInstances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourseInstanceID,Dept,Number,Semester,Year,Description")] CourseInstance courseInstance)
        {
            if (ModelState.IsValid)
            {
                _context.Add(courseInstance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(courseInstance);
        }

        // GET: CourseInstances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseInstance = await _context.Courses.FindAsync(id);
            if (courseInstance == null)
            {
                return NotFound();
            }
            return View(courseInstance);
        }

        // POST: CourseInstances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CourseInstanceID,Dept,Number,Semester,Year,Description")] CourseInstance courseInstance)
        {
            if (id != courseInstance.CourseInstanceID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(courseInstance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseInstanceExists(courseInstance.CourseInstanceID))
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
            return View(courseInstance);
        }

        // GET: CourseInstances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseInstance = await _context.Courses
                .FirstOrDefaultAsync(m => m.CourseInstanceID == id);
            if (courseInstance == null)
            {
                return NotFound();
            }

            return View(courseInstance);
        }

        // POST: CourseInstances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var courseInstance = await _context.Courses.FindAsync(id);
            _context.Courses.Remove(courseInstance);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Queries courses based on the current user's email address
        /// </summary>
        /// <returns></returns>
        public IActionResult MyCourses()
        {
            string user = User.Identity.Name;
            var courseInstances = _context.Courses.Where(m => m.InstructorEmail == user);
            return View(courseInstances);
        }

        public IActionResult CourseLearningOutcomes(int id)
        {
            var courseInstance = _context.Descriptions
                .Where(m => m.CourseInstanceID == id).ToList();
            return View(courseInstance);
        }

        [HttpPost]
        public JsonResult ChangeNote(string note, int note_id)
        {
           return Json(new { success = true });
        }

        private bool CourseInstanceExists(int id)
        {
            return _context.Courses.Any(e => e.CourseInstanceID == id);
        }
    }
}
