using System.Collections.Generic;
using DentAda.Business.BusinessLogic.Locator;
using DentAda.Business.ViewModel.Administration;
using DentAda.Common;
using DentAda.Web.Attributes;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace DentAda.Web.Areas.Main.Controllers
{
    [Area("Main")]
    public class TeamController : BaseController
    {
        private IMemoryCache _memoryCache;
        private AdministrationBLLocator _adminlocator;
        private IHostingEnvironment _env;
        public TeamController(AdministrationBLLocator adminLocator, IMemoryCache memoryCache, IHostingEnvironment env) : base(env)
        {
            _env = env;
            _memoryCache = memoryCache;
            _adminlocator = adminLocator;
        }
        [ContactUsAttribute]
        public IActionResult Index()
        {
            ViewBag.ContactUs = JsonConvert.DeserializeObject<List<ContactUsVM>>(HttpContext.Session.GetString("ContactUsData"));
            ViewBag.Persons = _adminlocator.PersonBL.GetVM(filter: m => m.Department == 1 && m.OperationIsDeleted == (short)_Enumeration._Department.Cayyolu);

            return View();
        }
    }
}