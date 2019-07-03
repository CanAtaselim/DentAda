using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DentAda.Business.BusinessLogic.Locator;
using DentAda.Business.ViewModel.Administration;
using DentAda.Data.Model;
using DentAda.Web.Attributes;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DentAda.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = new string[] { "SYSTEM_ADMIN", "ADMIN" })]
    public class AboutUsController : BaseController
    {
        private AdministrationBLLocator _administrationBLLocator;
        private IHostingEnvironment _env;
        public AboutUsController(AdministrationBLLocator administrationBLLocator, IHostingEnvironment env) : base(env)
        {
            _administrationBLLocator = administrationBLLocator;
            _env = env;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult FileUpload(IList<IFormFile> files, AboutUsVM model)
        {

            byte[] imageData = null;
            if (files.Count > 0)
            {
                imageData = GetFormImageToByte(files[0]);
            }


            AboutUs aboutUs = new AboutUs();
            aboutUs.Department = model.Department;
            aboutUs.Description = model.Description;
            aboutUs.Picture = imageData;
            aboutUs.OperationDate = DateTime.Now;
            aboutUs.OperationIdUserRef = HttpRequestInfo.UserID;
            aboutUs.OperationIP = HttpRequestInfo.IpAddress;
            aboutUs.OperationIsDeleted = 1;



            if (model.IdAboutUs == 0)
            {
                _administrationBLLocator.AboutUsBL.CRUD.Insert(aboutUs);
            }
            else
            {
                aboutUs.IdAboutUs = model.IdAboutUs;
                _administrationBLLocator.AboutUsBL.CRUD.Update(aboutUs, HttpRequestInfo);
            }
            _administrationBLLocator.AboutUsBL.Save();
            return View();
        }

        public IActionResult ReInvokeEditComponent(int Department)
        {
            return ViewComponent("Edit", new { department = Department });
        }

        public static byte[] GetFormImageToByte(IFormFile image)
        {
            byte[] data = null;
            if (image != null && image.Length > 0)
            {
                using (Stream inputStream = image.OpenReadStream())
                {
                    MemoryStream memoryStream = inputStream as MemoryStream;
                    if (memoryStream == null)
                    {
                        memoryStream = new MemoryStream();
                        inputStream.CopyTo(memoryStream);
                    }
                    data = memoryStream.ToArray();
                }

            }
            return data;
        }

    }
}