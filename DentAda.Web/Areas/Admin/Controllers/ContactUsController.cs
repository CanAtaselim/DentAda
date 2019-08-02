using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DentAda.Business.BusinessLogic.Locator;
using DentAda.Web.Attributes;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace DentAda.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = new string[] { "SYSTEM_ADMIN", "ADMIN" })]
    public class ContactUsController : BaseController
    {
        private AdministrationBLLocator _administrationBLLocator;
        public ContactUsController(AdministrationBLLocator administrationBLLocator, IHostingEnvironment env) : base(env)
        {
            _administrationBLLocator = administrationBLLocator;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}