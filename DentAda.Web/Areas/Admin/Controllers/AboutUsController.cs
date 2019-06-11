using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DentAda.Business.BusinessLogic.Locator;
using DentAda.Business.ViewModel.Administration;
using DentAda.Data.DataCommon;
using DentAda.Data.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DentAda.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
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
        

            byte[] imageData = GetFormImageToByte(files[0]);

            AboutUs au = new AboutUs();
            au.Department = model.Department;
            au.Description = model.Description;
            au.Picture = imageData;
            au.OperationDate = DateTime.Now;
            au.OperationIdUserRef = 1;
            au.OperationIP = "ss";
            au.OperationIsDeleted = 1;
            _administrationBLLocator.AboutUsBL.CRUD.Insert(au);
            _administrationBLLocator.AboutUsBL.Save();






            return View();
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