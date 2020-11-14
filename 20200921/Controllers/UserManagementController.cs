﻿using _20200921.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _20200921.Controllers
{
    public class UserManagementController : Controller
    {
        private UserManager<IdentityUser> userManager;
        private RoleManager<IdentityRole> roleManager;

        public UserManagementController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View(userManager.Users);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            IEnumerable<string> userRoles = await userManager.GetRolesAsync(user);
            IEnumerable<string> allRoles = roleManager.Roles.Select(r => r.Name);
            return View(new ChangeUserViewModel {
                User = user,
                UserRoles = userRoles,
                AllRoles = allRoles
            });
        }
    }
}
