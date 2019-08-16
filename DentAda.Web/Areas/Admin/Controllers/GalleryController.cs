﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DentAda.Business.BusinessLogic.Locator;
using DentAda.Business.ViewModel.Administration;
using DentAda.Web.Attributes;
using DentAda.Web.WebCommon;
using ImageMagick;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DentAda.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = new string[] { "SYSTEM_ADMIN", "ADMIN" })]
    public class GalleryController : BaseController
    {
        private AdministrationBLLocator _administrationBLLocator;
        private IHostingEnvironment _env;


        public GalleryController(AdministrationBLLocator administrationBLLocator, IHostingEnvironment env) : base(env)
        {
            _administrationBLLocator = administrationBLLocator;
            _env = env;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult List(int Department = 1)
        {
            return ViewComponent("GalleryEdit", new { Department });
        }

        [HttpPost]
        public async Task<IActionResult> Save(GalleryVM galleryVM)
        {
            AjaxMessage aMsg = new AjaxMessage();
            var files = Request.Form.Files;
            if (files.Count > 0)
            {
                var totalFileSize = 25 * 1024 * 1024;
                if (files.Sum(m => m.Length) > totalFileSize)
                {
                    aMsg.Status = 0;
                    aMsg.Message = "25 MB limitiniz aştınız.";
                }
                else
                {
                    string departmentName = galleryVM.Department == 1 ? "cayyolu" : "polatli";
                    string lowresDirectory = Path.Combine(_env.WebRootPath, "images\\gallery\\" + departmentName + "\\lowres");
                    string thumbnailDirectory = Path.Combine(_env.WebRootPath, "images\\gallery\\" + departmentName + "\\thumbnail");
                    if (!Directory.Exists(lowresDirectory))
                    {
                        Directory.CreateDirectory(lowresDirectory);
                    }
                    if (!Directory.Exists(thumbnailDirectory))
                    {
                        Directory.CreateDirectory(thumbnailDirectory);
                    }
                    foreach (IFormFile image in files)
                    {
                        int fileSizeLimit = 4 * 1024 * 1024;
                        if (image.Length < fileSizeLimit)
                        {
                            string imageName = Guid.NewGuid().ToString();
                            string imageExtension = Path.GetExtension(image.FileName);

                            try
                            {
                                ConvertLowres(lowresDirectory, image, imageName, imageExtension);
                            }
                            catch (Exception ex)
                            {

                            }

                            try
                            {
                                ConvertThumbnail(thumbnailDirectory, image, imageName, imageExtension);
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                    }
                    aMsg.Status = 1;
                    aMsg.Message = "Fotoğraf ekleme işlemi başarılı";
                }
            }
            else
            {
                aMsg.Status = 0;
                aMsg.Message = "Lütfen fotoğraf seçiniz.";

            }
            return Json(aMsg);
        }

        private static void ConvertThumbnail(string thumbnailDirectory, IFormFile image, string imageName, string imageExtension)
        {

            using (MagickImage imageFile = new MagickImage(GetFormImageToByte(image)))
            {

                MagickGeometry reSize = new MagickGeometry(200);
                imageFile.AutoOrient();
                //reSize.IgnoreAspectRatio = false;
                imageFile.Resize(reSize);
                imageFile.Write(Path.Combine(thumbnailDirectory, imageName + imageExtension));
            }
        }
        private static void ConvertLowres(string lowresDirectory, IFormFile image, string imageName, string imageExtension)
        {

            using (MagickImage imageFile = new MagickImage(GetFormImageToByte(image)))
            {

                MagickGeometry reSize = new MagickGeometry(new Percentage(90), new Percentage(90));
                imageFile.AutoOrient();
                //reSize.IgnoreAspectRatio = false;
                imageFile.Resize(reSize);
                imageFile.Write(Path.Combine(lowresDirectory, imageName + imageExtension));
            }
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