using DentAda.Business.BusinessLogic.Locator;
using DentAda.Business.ViewModel.Administration;
using DentAda.Common;
using DentAda.Web.Attributes;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DentAda.Web.Areas.Main.Controllers
{
    [Area("Main")]
    public class HomeController : BaseController
    {
        private IMemoryCache _memoryCache;
        private AdministrationBLLocator _adminlocator;
        private IHostingEnvironment _env;
        public HomeController(AdministrationBLLocator adminLocator, IMemoryCache memoryCache, IHostingEnvironment env) : base(env)
        {
            _env = env;
            _memoryCache = memoryCache;
            _adminlocator = adminLocator;
        }

        [ContactUsAttribute]
        public IActionResult Index()
        {

            ViewBag.ContactUs = JsonConvert.DeserializeObject<List<ContactUsVM>>(HttpContext.Session.GetString("ContactUsData"));
            ViewBag.Persons = _adminlocator.PersonBL.GetVM(filter: m => m.EmployeeType == (short)_Enumeration._EmployeeType.Managers && m.OperationIsDeleted == (short)_Enumeration.IsOperationDeleted.Active);
            ViewBag.Services = _adminlocator.ServicesBL.GetVM(filter: m => m.OperationIsDeleted == (short)_Enumeration.IsOperationDeleted.Active).Take(4).ToList();
            ViewBag.AboutUs = _adminlocator.AboutUsBL.GetVM(filter: m => m.OperationIsDeleted == (short)_Enumeration.IsOperationDeleted.Active).FirstOrDefault();

            return View();
        }
        public FileContentResult GetImageFilePath(long idPerson)
        {
            try
            {
                if (idPerson == 0)
                {
                    var uploads = Path.Combine(_env.WebRootPath, "frontend/images");
                    byte[] fileBytes = System.IO.File.ReadAllBytes(Path.Combine(uploads, "noPersonImage.png"));
                    return new FileContentResult(fileBytes, "image/jpeg");
                }
                else
                {
                    var person = _adminlocator.PersonBL.CRUD.GetById(idPerson);
                    return new FileContentResult(person.Picture, "image/jpeg");
                }
            }
            catch (Exception)
            {
                var uploads = Path.Combine(_env.WebRootPath, "frontend/images");
                byte[] fileBytes = System.IO.File.ReadAllBytes(Path.Combine(uploads, "noPersonImage.png"));
                return new FileContentResult(fileBytes, "image/jpeg");
            }

        }

    }
}