/**
 * Author:    Kaelin Hoang
 * Partner:   Khanhly Nguyen
 * Date:      10/18/2019
 * Course:    CS 4540, University of Utah, School of Computing
 * Copyright: CS 4540 and Kaelin Hoang - This work may not be copied for use in Academic Coursework.
 *
 * I, Kaelin Hoang, certify that I wrote this code from scratch and did not copy it in part or whole from 
 * another source.  Any references used in the completion of the assignment are cited in my README file.
 *
 * File Contents
 *
 *    Controls all views
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public HomeController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
       

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Course()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Professor()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Department()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Home()
        {
            return View();
        }

        [Authorize(Roles ="Admin")]
        public IActionResult RoleChange()
        {
            return View();
        }



        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
