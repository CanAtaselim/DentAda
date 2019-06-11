using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DentAda.Web.Areas.Auth.Controllers
{
    [Area("Auth")]
    public class LoginController : BaseController
    {
        public IActionResult Unauthorized()
        {
            return View();
        }
        public async Task<IActionResult> SignOut()
        {
            return RedirectToAction("Unauthorized");

        }

    }
}