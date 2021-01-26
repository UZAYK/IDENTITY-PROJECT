using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityProject.Controllers
{
    public class DeveloperController : Controller
    {
        [Authorize(Roles = "Admin, Developer")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
