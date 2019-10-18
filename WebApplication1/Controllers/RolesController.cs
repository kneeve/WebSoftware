using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IActionResult> AddRole(string user_name, string changeRole, string add_remove)
        {
            var user = await _userManager.FindByNameAsync(user_name);
            var role = await _roleManager.FindByNameAsync(changeRole);
            var admins = await _userManager.GetUsersInRoleAsync("Admin");
            int numAdmins = ((IList)admins).Count;

            bool add = add_remove.Equals("add");
            if (add)
            {
                await _userManager.AddToRoleAsync(user, role.Name);
            }
            else
            {
                if (changeRole.Equals("Admin") && numAdmins == 1)
                {
                    return Json(new { Success = false }); // TODO: Sending a fail back to ajax
                }

                await _userManager.RemoveFromRoleAsync(user, role.Name);
                
            }
            return Json(new { Success = true });
        }
    }
}