/**
 * Author:    Kaelin Hoang
 * Partner:   Khanhly Nguyen
 * Date:      10/18/2019
 * Course:    CS 4540, University of Utah, School of Computing
 * Copyright: CS 4540 and Kaelin Hoang - This work may not be copied for use in Academic Coursework.
 *
 * Kaelin Hoang and Khanhly Nguyen, certify that I wrote this code from scratch and did not copy it in part or whole from 
 * another source.  Any references used in the completion of the assignment are cited in my README file.
 *
 * File Contents
 *
 *    Controls the role change logic from the role change view
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class RolesController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public RolesController(UserManager<IdentityUser> user, RoleManager<IdentityRole> role)
        {
            _userManager = user;
            _roleManager = role;
        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Add or removes a user from a given role. Checks for admin error as well.
        /// Returns OK status for successful add/remove.
        /// Returns BadRequest for trying to remove an admin when there is only 1.
        /// </summary>
        /// <param name="user_name"></param>
        /// <param name="changeRole"></param>
        /// <param name="add_remove"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> AddRole(string user_name, string changeRole, string add_remove)
        {
            var user = await _userManager.FindByNameAsync(user_name);
            var role = await _roleManager.FindByNameAsync(changeRole);
            var admins = await _userManager.GetUsersInRoleAsync("Admin");
            int numAdmins = ((IList)admins).Count;

            bool add = add_remove.Equals("add");
            if (add)
            {
                await _userManager.AddToRoleAsync(user, role.Name);
                return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            }
            else
            {
                if (changeRole.Equals("Admin") && numAdmins == 1)
                {
                    return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, role.Name);
                    return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
                }
            }
        }
    }
}