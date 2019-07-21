using DentAda.Business.BusinessLogic.Locator;
using DentAda.Business.ViewModel.Administration;
using DentAda.Common;
using DentAda.Web.Attributes;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DentAda.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = new string[] { "SYSTEM_ADMIN", "ADMIN" })]

    public class PersonController : BaseController
    {
        private AdministrationBLLocator _administrationBLLocator;


        private IHostingEnvironment _env;

        public PersonController(AdministrationBLLocator administrationBLLocator, IHostingEnvironment env) : base(env)
        {
            _administrationBLLocator = administrationBLLocator;
            _env = env;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ReInvokeEditComponent()
        {
            return ViewComponent("PersonEdit");
        }

        public JsonResult GetUniversity(string search)
        {
            List<UniversitiesVM> universities = _administrationBLLocator.UniversitiesBL.GetVM(filter: m => m.Name.Contains(search) && m.OperationIsDeleted == (short)_Enumeration.IsOperationDeleted.Active, take: 2);

            var newJson = JsonConvert.SerializeObject(universities);
            return Json(newJson);
        }
    }
}