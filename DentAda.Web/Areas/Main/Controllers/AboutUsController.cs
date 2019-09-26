﻿using DentAda.Business.BusinessLogic.Locator;
using DentAda.Business.ViewModel.Administration;
using DentAda.Common;
using DentAda.Web.Attributes;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace DentAda.Web.Areas.Main.Controllers
{
    [Area("Main")]
    public class AboutUsController : BaseController
    {
        private IMemoryCache _memoryCache;
        private AdministrationBLLocator _adminlocator;
        private IHostingEnvironment _env;
        public AboutUsController(AdministrationBLLocator adminLocator, IMemoryCache memoryCache, IHostingEnvironment env) : base(env)
        {
            _env = env;
            _memoryCache = memoryCache;
            _adminlocator = adminLocator;
        }
        [ContactUsAttribute]
        public IActionResult Index()
        {
            ViewBag.ContactUs = JsonConvert.DeserializeObject<List<ContactUsVM>>(HttpContext.Session.GetString("ContactUsData"));
            ViewBag.AboutUs = _adminlocator.AboutUsBL.GetVM(filter: m => m.OperationIsDeleted == (short)_Enumeration.IsOperationDeleted.Active).FirstOrDefault();
            return View();
        }
    }
}