using System;
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

        public async void AddRole(string user_name, string changeRole, string add_remove)
        {
            var user = await _userManager.FindByNameAsync(user_name);
            var role = await _roleManager.FindByNameAsync(changeRole);
            bool add = add_remove.Equals("add");
            if (add)
            {
                await _userManager.AddToRoleAsync(user, role.Name);
            }
            else
            {
                await _userManager.RemoveFromRoleAsync(user, role.Name);
            }
        }
    }
}